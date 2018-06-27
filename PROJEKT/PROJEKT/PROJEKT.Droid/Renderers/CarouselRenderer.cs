using Android.Graphics;
using Android.Views;
using Android.Widget;
using Java.Lang;
using PROJEKT.Droid.Renderers;
using PROJEKT.Views.Controls;
using System.ComponentModel;
using System.Reflection;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCarouselView), typeof(CarouselRenderer))]
namespace PROJEKT.Droid.Renderers
{
    public class CarouselRenderer : ScrollViewRenderer
    {
        private int _scrollX;
        private int _X;
        private bool _mD;
        private Timer _timer;
        private HorizontalScrollView _hScrollView;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;

            _timer = new Timer(200) { AutoReset = false };
            _timer.Elapsed += (object sender, ElapsedEventArgs args2) => UpdateSelectedIndex();

            e.NewElement.PropertyChanged += ElementPropertyChanged;
        }

        void ElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Renderer")
            {
                _hScrollView = (HorizontalScrollView)typeof(ScrollViewRenderer)
                    .GetField("_hScrollView", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(this);

                _hScrollView.HorizontalScrollBarEnabled = false;
                _hScrollView.Touch += HScrollViewTouch;
            }
            if (e.PropertyName == MyCarouselView.SelectedIndexProperty.PropertyName && !_mD)
            {
                ScrollToIndex(((MyCarouselView)this.Element).SelectedIndex);
            }
        }

        void HScrollViewTouch(object sender, TouchEventArgs e)
        {
            e.Handled = false;

            if (_hScrollView.ScrollX > _hScrollView.ScrollY)
            {
                switch (e.Event.Action)
                {
                    case MotionEventActions.Move:
                        _X = _hScrollView.ScrollX - _scrollX;
                        _scrollX = _hScrollView.ScrollX;
                        UpdateSelectedIndex();
                        break;
                    case MotionEventActions.Down:
                        _mD = true;
                        _timer.Stop();
                        break;
                    case MotionEventActions.Up:
                        _mD = false;
                        SnapScroll();
                        _timer.Start();
                        break;
                }
            }
        }

        void UpdateSelectedIndex()
        {
            var center = _hScrollView.ScrollX + (_hScrollView.Width / 2);
            var carouselLayout = (MyCarouselView)this.Element;
            var targetIndex = _X < 0 ? (int)Java.Lang.Math.Floor((center / _hScrollView.Width))
                : _X > 0 ? (int)Java.Lang.Math.Ceil((center / _hScrollView.Width))
                : Java.Lang.Math.Round((center / _hScrollView.Width));
            if (targetIndex != carouselLayout.SelectedIndex)
            {
                carouselLayout.SelectedIndex = targetIndex;
                if (targetIndex == 0)
                {
                    carouselLayout.SelectedItem = carouselLayout.Children[0];
                }
            }
            carouselLayout.ChangeBackground(targetIndex);
        }

        void SnapScroll()
        {
            var roughIndex = (float)_hScrollView.ScrollX / _hScrollView.Width;

            var targetIndex =
                _X < 0 ? Java.Lang.Math.Floor(roughIndex)
                : _X > 0 ? Java.Lang.Math.Ceil(roughIndex)
                : Java.Lang.Math.Round(roughIndex);
            ScrollToIndex((int)targetIndex);
        }

        void ScrollToIndex(int targetIndex)
        {
            _hScrollView.Post(new Runnable(() =>
            {
                _hScrollView.SmoothScrollTo(targetIndex * _hScrollView.Width, 0);
            }));
        }

        bool _initialized = false;
        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            if (_initialized) return;
            _initialized = true;
            var carouselLayout = (MyCarouselView)this.Element;
            _hScrollView.ScrollTo(carouselLayout.SelectedIndex * Width, 0);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            if (_initialized && (w != oldw))
            {
                _initialized = false;
            }
            base.OnSizeChanged(w, h, oldw, oldh);
        }
    }
}