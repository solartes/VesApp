using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using VesApp.iOS;
using VesApp.CustomRender;

[assembly: ExportRenderer(typeof(ShortLabel2), typeof(ShortLabelRender2))]
namespace VesApp.iOS
{
    public class ShortLabelRender2 : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                UILabel label = Control;
                label.Lines = 5;
            }
        }
    }
}