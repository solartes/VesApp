using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using VesApp.iOS;

[assembly: ExportRenderer(typeof(Label), typeof(LabelLinesRender))]
namespace VesApp.iOS
{
    public class LabelLinesRender : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                UILabel label = Control;
                label.Lines = 2;
            }
        }
    }
}