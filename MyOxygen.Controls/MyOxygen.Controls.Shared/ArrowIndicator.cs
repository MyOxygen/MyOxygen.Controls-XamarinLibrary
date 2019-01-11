using System;
using Xamarin.Forms;

namespace MyOxygen.Controls
{
    public class ArrowIndicator : TintedImage
    {
        #region Global variables

        private SizeEnum arrowSize = SizeEnum.Normal;
        private OrientationEnum orientation = OrientationEnum.PointingLeft;

        public enum OrientationEnum
        {
            PointingLeft,
            PointingUp,
            PointingRight,
            PointingDown
        }

        public enum SizeEnum
        {
            Smaller,
            Normal,
            Larger
        }

        #endregion

        #region Public properties

        public OrientationEnum Orientation
        {
            get => orientation;
            set => SetOrientation(value);
        }

        public SizeEnum ArrowSize
        {
            get => arrowSize;
            set => SetArrowSize(value);
        }

        #endregion

        #region Constructor

        public ArrowIndicator()
        {
            Aspect = Aspect.AspectFit;
            HeightRequest = 24;
            HorizontalOptions = LayoutOptions.Center;
            TintColor = Color.Black;
            VerticalOptions = LayoutOptions.Center;

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    Source = ImageSource.FromFile("BackArrowIcon");
                    break;

                case Device.iOS:
                    Source = ImageSource.FromFile("BackArrow/BackArrowIcon");
                    break;
            }
        }

        #endregion

        #region Other methods

        private void SetArrowSize(SizeEnum newArrowSize)
        {
            arrowSize = newArrowSize;

            switch (arrowSize)
            {
                case SizeEnum.Larger:
                    Scale = 1.25;
                    break;

                case SizeEnum.Normal:
                    Scale = 1.0;
                    break;

                case SizeEnum.Smaller:
                    Scale = 0.75;
                    break;
            }
        }

        private void SetOrientation(OrientationEnum newOrientation)
        {
            orientation = newOrientation;

            switch (orientation)
            {
                case OrientationEnum.PointingDown:
                    Rotation = 270;
                    break;

                case OrientationEnum.PointingLeft:
                    Rotation = 0;
                    break;

                case OrientationEnum.PointingRight:
                    Rotation = 180;
                    break;

                case OrientationEnum.PointingUp:
                    Rotation = 90;
                    break;
            }
        }

        #endregion
    }
}
