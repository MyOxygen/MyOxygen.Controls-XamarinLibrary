using MyOxygen.Controls;
using MyOxygen.Controls.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CircleView), typeof(CircleViewRenderer))]
namespace MyOxygen.Controls.iOS
{
    public class CircleViewRenderer : BoxRenderer
    {
        private CircleView CustomElement => Element as CircleView;

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (Element == null)
            {
                return;
            }

            Layer.MasksToBounds = true;
            Layer.CornerRadius = (float)CustomElement.Radius / 2.0f;
        }
    }
}
