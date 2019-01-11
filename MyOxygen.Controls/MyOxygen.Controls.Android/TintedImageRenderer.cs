using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using MyOxygen.Controls;
using MyOxygen.Controls.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRendererAttribute(typeof(TintedImage), typeof(TintedImageRenderer))]
namespace MyOxygen.Controls.Droid
{
    public class TintedImageRenderer : ImageRenderer
    {
        private TintedImage CustomElement => Element as TintedImage;

        public TintedImageRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            SetTint();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
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
                (Element == null))
            {
                return;
            }

            if (CustomElement.TintColor.Equals(Xamarin.Forms.Color.Transparent))
            {
                //Turn off tinting

                if (Control.ColorFilter != null)
                {
                    Control.ClearColorFilter();
                }

                return;
            }

            //Apply tint color
            var colorFilter = new PorterDuffColorFilter(CustomElement.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            Control.SetColorFilter(colorFilter);
        }
    }
}
