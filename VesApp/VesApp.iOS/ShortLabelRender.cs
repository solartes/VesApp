using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using VesApp.iOS;
using VesApp.CustomRender;

[assembly: ExportRenderer(typeof(ShortLabel), typeof(ShortLabelRender))]
namespace VesApp.iOS
{
    public class ShortLabelRender : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                UILabel label = Control;
                label.Lines = 7;
            }
        }
    }
}