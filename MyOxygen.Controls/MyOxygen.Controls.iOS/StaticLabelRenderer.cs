using System;
using System.ComponentModel;
using MyOxygen.Controls;
using MyOxygen.Controls.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(StaticLabel), typeof(StaticLabelRenderer))]
namespace MyOxygen.Controls.iOS
{
    public class StaticLabelRenderer : LabelRenderer
    {
        public StaticLabelRenderer() : base()
        {
        }
    }
}
