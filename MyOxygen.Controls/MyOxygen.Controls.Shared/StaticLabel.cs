using Xamarin.Forms;

namespace MyOxygen.Controls
{
    /// <summary><see cref="T:Xamarin.Forms.Label" /> that fixes text alignment 
    /// issues on Android. To be used just like a regular <see cref="T:Xamarin.Forms.Label" />.</summary>
    /// <remarks>
    /// This package fixes the text alignment issues seen on Android when the 
    /// alignment of a Label would reset to the default of left-aligned.
    /// </remarks>
    public class StaticLabel : Label
    {
        public StaticLabel()
        {
        }
    }
}
