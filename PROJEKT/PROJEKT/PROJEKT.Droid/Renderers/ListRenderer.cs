using PROJEKT.Droid.Renderers;
using PROJEKT.Views.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyListView), typeof(ListRenderer))]
namespace PROJEKT.Droid.Renderers
{
    public class ListRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.NestedScrollingEnabled = true;
                Control.SmoothScrollbarEnabled = true;
                Control.VerticalScrollBarEnabled = true;
                Control.FastScrollEnabled = true;
            }
        }
    }
}