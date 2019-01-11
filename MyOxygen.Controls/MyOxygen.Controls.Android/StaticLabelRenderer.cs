using System;
using System.ComponentModel;
using Android.Content;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using MyOxygen.Controls;
using MyOxygen.Controls.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(StaticLabel), typeof(StaticLabelRenderer))]
namespace MyOxygen.Controls.Droid
{
    public class StaticLabelRenderer : LabelRenderer
    {
        // Solution was suggested by a comment from a Xamarin developer on Github:
        // https://github.com/xamarin/Xamarin.Forms/issues/2167#issuecomment-389637460


        private TextView textView;

        private StaticLabel CustomElement => Element as StaticLabel;

        public StaticLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                textView = Control;

                SetTextViewGravity(ref textView);

                SetNativeControl(textView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            SetTextViewGravity(ref textView);

            SetNativeControl(textView);
        }

        protected override void DrawableStateChanged()
        {
            base.DrawableStateChanged();

            SetTextViewGravity(ref textView);

            SetNativeControl(textView);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            SetTextViewGravity(ref textView);

            SetNativeControl(textView);
        }

        protected override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            SetTextViewGravity(ref textView);

            SetNativeControl(textView);
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);

            SetTextViewGravity(ref textView);

            SetNativeControl(textView);
        }



        private void SetTextViewGravity(ref TextView refTextView)
        {
            GravityFlags gravity =
                (GetHorizontalTextAlignmentAsGravityFlag() |
                 GetVerticalTextAlignmentAsGravityFlag());

            refTextView.Gravity = gravity;
        }

        private GravityFlags GetHorizontalTextAlignmentAsGravityFlag()
        {
            switch (CustomElement.HorizontalTextAlignment)
            {
                default:
                case Xamarin.Forms.TextAlignment.Start:
                    return GravityFlags.Left;

                case Xamarin.Forms.TextAlignment.Center:
                    return GravityFlags.CenterHorizontal;

                case Xamarin.Forms.TextAlignment.End:
                    return GravityFlags.Right;
            }
        }

        private GravityFlags GetVerticalTextAlignmentAsGravityFlag()
        {
            switch (CustomElement.VerticalTextAlignment)
            {
                default:
                case Xamarin.Forms.TextAlignment.Start:
                    return GravityFlags.Top;

                case Xamarin.Forms.TextAlignment.Center:
                    return GravityFlags.CenterVertical;

                case Xamarin.Forms.TextAlignment.End:
                    return GravityFlags.Bottom;
            }
        }
    }
}
