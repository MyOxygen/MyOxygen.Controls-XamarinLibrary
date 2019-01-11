using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyOxygen.Controls
{
    public partial class Checkbox : ContentView
    {
        #region Global variables

        private const int CircleScaleTime = 300;
        private const int CircleFadeTime = 150;

        private const int TickScaleTime = 75;
        private const int TickFadeTime = 150;

        public enum TextPositionEnum
        {
            ToTheRight,
            Below,
            ToTheLeft,
            Above
        };

        #endregion

        #region Bindable Properties

        public static BindableProperty CheckBoxColorProperty =
            BindableProperty.Create(
                propertyName: nameof(CheckBoxColor),
                returnType: typeof(Color),
                declaringType: typeof(Checkbox),
                defaultValue: Color.Black,
                propertyChanged: HandleCheckBoxColorPropertyChanged);

        public static BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: nameof(Command),
                returnType: typeof(ICommand),
                declaringType: typeof(Checkbox),
                defaultValue: null);

        public static BindableProperty CommandParameterProperty =
            BindableProperty.Create(
                propertyName: nameof(CommandParameter),
                returnType: typeof(object),
                declaringType: typeof(Checkbox),
                defaultValue: null);

        public static BindableProperty FormattedTextProperty =
            BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(FormattedString),
                declaringType: typeof(Checkbox),
                defaultValue: null,
                propertyChanged: HandleFormattedTextPropertyChanged);

        public static BindableProperty IsCheckedProperty =
            BindableProperty.Create(
                propertyName: nameof(IsChecked),
                returnType: typeof(bool),
                declaringType: typeof(Checkbox),
                defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: HandleIsCheckedPropertyChanged);

        public static BindableProperty TextProperty =
            BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(Checkbox),
                defaultValue: null,
                propertyChanged: HandleTextPropertyChanged);

        public static BindableProperty TextPositionProperty =
            BindableProperty.Create(
                propertyName: nameof(TextPosition),
                returnType: typeof(TextPositionEnum),
                declaringType: typeof(Checkbox),
                defaultValue: TextPositionEnum.ToTheRight,
                propertyChanged: HandleTextPositionPropertyChanged);

        #endregion

        #region Properties

        public Color CheckBoxColor
        {
            get => (Color)GetValue(CheckBoxColorProperty);
            set => SetValue(CheckBoxColorProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => (object)GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public FormattedString FormattedText
        {
            get => (FormattedString)GetValue(FormattedTextProperty);
            set => SetValue(FormattedTextProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public TextPositionEnum TextPosition
        {
            get => (TextPositionEnum)GetValue(TextPositionProperty);
            set => SetValue(TextPositionProperty, value);
        }

        #endregion

        #region Constructor

        public Checkbox()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers


        private void Handle_Tapped(object sender, System.EventArgs e)
        {
            IsChecked = !IsChecked;

            Command?.Execute(CommandParameter);
        }


        private static void HandleCheckBoxColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Checkbox control = (Checkbox)bindable;
            if (control != null)
            {
                control.ImageChecked.TintColor = (Color)newValue;
                control.ImageUnchecked.TintColor = (Color)newValue;
            }
        }


        private static void HandleFormattedTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Checkbox control = (Checkbox)bindable;
            if (control != null)
            {
                control.CurrentCheckboxLabel.FormattedText = (FormattedString)newValue;

                CheckTextAndAssignLabel(control);
            }
        }


        private static void HandleIsCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Checkbox control = (Checkbox)bindable;
            if (control != null)
            {
                control.IsChecked = (bool)newValue;
                control.TapCircleAnimation();
                control.AnimateCheckbox(control.IsChecked);
            }
        }


        private static void HandleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Checkbox control = (Checkbox)bindable;
            if (control != null)
            {
                control.CurrentCheckboxLabel.Text = (string)newValue;

                CheckTextAndAssignLabel(control);
            }
        }


        private static void HandleTextPositionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Checkbox control = (Checkbox)bindable;
            if ((control != null) &&
                (Enum.TryParse(newValue.ToString(), out TextPositionEnum newPosition)))
            {
                switch (newPosition)
                {
                    case TextPositionEnum.Above:
                        control.ContentLayout.Children.Clear();
                        control.ContentLayout.Orientation = StackOrientation.Vertical;
                        control.ContentLayout.Spacing = 0;
                        control.CurrentCheckboxLabel.HorizontalTextAlignment = TextAlignment.Center;
                        if (!String.IsNullOrWhiteSpace(control.CurrentCheckboxLabel.Text))
                        {
                            control.ContentLayout.Children.Add(control.CurrentCheckboxLabel);
                        }
                        control.ContentLayout.Children.Add(control.CurrentCheckboxCircle);
                        break;

                    case TextPositionEnum.Below:
                        control.ContentLayout.Children.Clear();
                        control.ContentLayout.Orientation = StackOrientation.Vertical;
                        control.ContentLayout.Spacing = 0;
                        control.CurrentCheckboxLabel.HorizontalTextAlignment = TextAlignment.Center;
                        control.ContentLayout.Children.Add(control.CurrentCheckboxCircle);
                        if (!String.IsNullOrWhiteSpace(control.CurrentCheckboxLabel.Text))
                        {
                            control.ContentLayout.Children.Add(control.CurrentCheckboxLabel);
                        }
                        break;

                    case TextPositionEnum.ToTheLeft:
                        control.ContentLayout.Children.Clear();
                        control.ContentLayout.Orientation = StackOrientation.Horizontal;
                        control.ContentLayout.Spacing = 10;
                        control.CurrentCheckboxLabel.HorizontalTextAlignment = TextAlignment.Start;
                        if (!String.IsNullOrWhiteSpace(control.CurrentCheckboxLabel.Text))
                        {
                            control.ContentLayout.Children.Add(control.CurrentCheckboxLabel);
                        }
                        control.ContentLayout.Children.Add(control.CurrentCheckboxCircle);
                        break;

                    case TextPositionEnum.ToTheRight:
                        control.ContentLayout.Children.Clear();
                        control.ContentLayout.Orientation = StackOrientation.Horizontal;
                        control.ContentLayout.Spacing = 10;
                        control.CurrentCheckboxLabel.HorizontalTextAlignment = TextAlignment.Start;
                        control.ContentLayout.Children.Add(control.CurrentCheckboxCircle);
                        if (!String.IsNullOrWhiteSpace(control.CurrentCheckboxLabel.Text))
                        {
                            control.ContentLayout.Children.Add(control.CurrentCheckboxLabel);
                        }
                        break;
                }
            }
        }

        #endregion

        #region Other methods

        private static void CheckTextAndAssignLabel(Checkbox control)
        {
            // Check is the Label is there.
            if (control.ContentLayout.Children.Count < 2)
            {
                // Label is not present. Check the validity of the (formatted)
                // text property and add the Label.
                if ((!String.IsNullOrWhiteSpace(control.CurrentCheckboxLabel.Text)) ||
                    (!String.IsNullOrWhiteSpace(control.FormattedText.ToString())))
                {
                    control.ContentLayout.Children.Add(control.CurrentCheckboxLabel);
                }
            }
            // Label is present. Check the validity of the (formatted) text
            // property and remove the Label.
            else if ((String.IsNullOrWhiteSpace(control.CurrentCheckboxLabel.Text)) &&
                     (String.IsNullOrWhiteSpace(control.FormattedText.ToString())))
            {
                control.ContentLayout.Children.Remove(control.CurrentCheckboxLabel);
            }
        }


        /// <summary>
        /// Shadow animation when the checkbox is tapped.
        /// </summary>
        internal void TapCircleAnimation()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                TapCircle.Scale = 0.5;
                TapCircle.ScaleTo(1, CircleScaleTime);
                await TapCircle.FadeTo(0.25, CircleFadeTime);
                TapCircle.FadeTo(0.0, CircleFadeTime);
            });
        }


        /// <summary>
        /// Play animation to grow and shrink
        /// </summary>
        internal void AnimateCheckbox(bool checkState)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (checkState)
                {
                    ImageUnchecked.ScaleTo(0.8, TickScaleTime);
                    ImageChecked.ScaleTo(0.8, TickScaleTime);
                    await ImageUnchecked.FadeTo(0, TickFadeTime);

                    ImageUnchecked.ScaleTo(1, TickScaleTime);
                    ImageChecked.ScaleTo(1, TickScaleTime);
                    await ImageChecked.FadeTo(1, TickFadeTime);
                }
                else
                {
                    ImageUnchecked.ScaleTo(0.8, TickScaleTime);
                    ImageChecked.ScaleTo(0.8, TickScaleTime);
                    await ImageChecked.FadeTo(0, TickFadeTime);

                    ImageUnchecked.ScaleTo(1, TickScaleTime);
                    ImageChecked.ScaleTo(1, TickScaleTime);
                    await ImageUnchecked.FadeTo(1, TickFadeTime);
                }
            });
        }

        #endregion

    }
}
