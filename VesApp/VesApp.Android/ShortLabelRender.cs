using VesApp.CustomRender;
using VesApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(ShortLabel), typeof(ShortLabelRender))]
namespace VesApp.Droid
{
    public class ShortLabelRender : LabelRenderer
    {
        public ShortLabelRender(Context context):base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetMaxLines(7);
            }
        }
    }

}