using VesApp.CustomRender;
using VesApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(ShortLabel2), typeof(ShortLabelRender2))]
namespace VesApp.Droid
{
    public class ShortLabelRender2 : LabelRenderer
    {
        public ShortLabelRender2(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetMaxLines(5);
            }
        }
    }

}