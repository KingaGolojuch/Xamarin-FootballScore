using PROJEKT.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PROJEKT.Views.Controls
{
    public class MyCarouselView : ScrollView
    {
        private StackLayout _layout;
        private int _selectedIndex;

        public CompetitionPage page { get; set; }
        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create(
                nameof(SelectedIndex),
                typeof(int),
                typeof(MyCarouselView),
                0,
                BindingMode.TwoWay,
                propertyChanged: async (bindable, oldValue, newValue) =>
                {
                    await ((MyCarouselView)bindable).UpdateItem();
                }
            );
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                nameof(ItemsSource),
                typeof(IList),
                typeof(MyCarouselView),
                null,
                propertyChanging: (bindableObject, oldValue, newValue) =>
                {
                    ((MyCarouselView)bindableObject).ItemsSourceChanging();
                },
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    ((MyCarouselView)bindableObject).ItemsSourceChanged();
                }
            );
        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(
                nameof(SelectedItem),
                typeof(object),
                typeof(MyCarouselView),
                null,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((MyCarouselView)bindable).Update();
                }
            );

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }
        public DataTemplate ItemTemplate
        {
            get;
            set;
        }
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public IList<View> Children
        {
            get { return _layout.Children; }
        }

        public MyCarouselView()
        {
            Orientation = ScrollOrientation.Horizontal;

            _layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0
            };

            Content = _layout;
        }

        private async Task UpdateItem()
        {
            await Task.Delay(100);
            SelectedItem = SelectedIndex > -1 ? Children[SelectedIndex].BindingContext : null;
        }

        private void ItemsSourceChanging()
        {
            if (ItemsSource == null) return;
            _selectedIndex = ItemsSource.IndexOf(SelectedItem);
        }

        public void ChangeBackground(int target)
        {
            if (page != null)
            {
                Task.Run(() =>
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        page.ChangeSelectedIndex(target);
                    })
                );
            }
        }

        private void ItemsSourceChanged()
        {
            _layout.Children.Clear();
            foreach (var item in ItemsSource)
            {
                CustomCompetition custom = (CustomCompetition)item;
                if (custom.Id == 1)
                {
                    ItemTemplate = new DataTemplate(typeof(CompetitionView));
                }
                else if (custom.Id == 2)
                {
                    ItemTemplate = new DataTemplate(typeof(FixturesView));
                }
                else if (custom.Id == 3)
                {
                    ItemTemplate = new DataTemplate(typeof(LeagueView));
                }
                else
                {
                    ItemTemplate = new DataTemplate(typeof(TeamsView));
                }
                var view = (View)ItemTemplate.CreateContent();
                var bindableObject = view as BindableObject;
                if (bindableObject != null)
                    bindableObject.BindingContext = item;
                _layout.Children.Add(view);
            }

            if (_selectedIndex > -1) SelectedIndex = _selectedIndex;
        }

        private void Update()
        {
            if (SelectedItem == BindingContext) return;

            SelectedIndex = this.Children
                .Select(c => c.BindingContext)
                .ToList()
                .IndexOf(SelectedItem);
        }
    }
}
