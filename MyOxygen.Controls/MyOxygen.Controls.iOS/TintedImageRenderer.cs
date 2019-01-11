using MyOxygen.Controls;
using MyOxygen.Controls.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(TintedImage), typeof(TintedImageRenderer))]
namespace MyOxygen.Controls.iOS
{
    public class TintedImageRenderer : ImageRenderer
    {
        private TintedImage CustomElement => Element as TintedImage;

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            SetTint();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if ((e.PropertyName == TintedImage.TintColorProperty.PropertyName) ||
                (e.PropertyName == TintedImage.SourceProperty.PropertyName))
            {
                SetTint();
            }
        }

        void SetTint()
        {
            if ((Control == null) ||
                (Control.Image == null) ||
                (Element == null))
            {
                return;
            }

            if (CustomElement.TintColor == Color.Transparent)
            {
                //Turn off tinting
                Control.Image = Control.Image.ImageWithRenderingMode(UIKit.UIImageRenderingMode.Automatic);
                Control.TintColor = null;
            }
            else
            {
                //Apply tint color
                Control.Image = Control.Image.ImageWithRenderingMode(UIKit.UIImageRenderingMode.AlwaysTemplate);
                Control.TintColor = CustomElement.TintColor.ToUIColor();
            }
        }
    }
}
