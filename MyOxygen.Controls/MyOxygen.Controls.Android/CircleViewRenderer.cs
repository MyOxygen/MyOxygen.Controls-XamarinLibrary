using Android.Content;
using Android.Graphics;
using Android.Util;
using MyOxygen.Controls;
using MyOxygen.Controls.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CircleView), typeof(CircleViewRenderer))]
namespace MyOxygen.Controls.Droid
{
    public class CircleViewRenderer : BoxRenderer
    {
        private float _cornerRadius;
        private RectF _bounds;
        private Path _path;

        private CircleView CustomElement => Element as CircleView;

        public CircleViewRenderer(Context context) : base(context)
        {
            // Required by default.
        }


        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if (Element == null)
            {
                return;
            }

            _cornerRadius = TypedValue.ApplyDimension(
                ComplexUnitType.Dip,
                (float)CustomElement.Radius,
                Context.Resources.DisplayMetrics);
        }


        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            if (w != oldw && h != oldh)
            {
                _bounds = new RectF(0, 0, w, h);
            }
            _path = new Path();
            _path.Reset();
            _path.AddRoundRect(_bounds, _cornerRadius, _cornerRadius, Path.Direction.Cw);
            _path.Close();
        }


        public override void Draw(Canvas canvas)
        {
            canvas.Save();
            canvas.ClipPath(_path);
            base.Draw(canvas);
            canvas.Restore();
        }
    }
}
