
using VesApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(LabelLinesRender))]
namespace VesApp.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class LabelLinesRender : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            Control.SetMaxLines(7);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}