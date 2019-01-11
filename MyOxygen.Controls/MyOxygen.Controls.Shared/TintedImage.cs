using Xamarin.Forms;

namespace MyOxygen.Controls
{
    /// <summary><see cref="T:Xamarin.Forms.Image" /> that overlays the image with a specified tint color.</summary>
    /// <remarks>
    /// <para>
    /// The following example creates a new image from a file
    /// </para>
    /// <example>
    /// <code lang="C#"><![CDATA[
    /// var image = new TintImage 
    /// { 
    ///     Source = "picture.png", 
    ///     TintColor = Color.Blue 
    /// };]]></code>
    /// </example>
    /// </remarks>
    public class TintedImage : Image
    {
        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create(
                propertyName: nameof(TintColor),
                returnType: typeof(Color),
                declaringType: typeof(TintedImage),
                defaultValue: Color.Black);

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }
    }
}
