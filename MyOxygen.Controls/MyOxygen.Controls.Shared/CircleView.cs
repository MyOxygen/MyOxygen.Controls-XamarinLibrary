using Xamarin.Forms;

namespace MyOxygen.Controls
{
    public class CircleView : BoxView
    {
        // Design for a custom circle view (XF doesn't allow by default)
        // Tutorial found at:
        // https://www.c-sharpcorner.com/article/xamarin-forms-rounded-boxview-using-custom-boxrenderer/

        // Add bindable property for the corner radius
        public static readonly BindableProperty RadiusProperty =
            BindableProperty.Create(
                propertyName: nameof(Radius),
                returnType: typeof(double),
                declaringType: typeof(CircleView),
                defaultValue: 0.0,
                propertyChanged: HandleRadiusPropertyChanged);

        public double Radius
        {
            get => (double)GetValue(RadiusProperty);
            set => SetValue(RadiusProperty, value);
        }

        private static void HandleRadiusPropertyChanged(
            BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CircleView)bindable;
            if (control != null)
            {
                control.HeightRequest = (double)newValue;
                control.WidthRequest = (double)newValue;
            }
        }
    }
}
