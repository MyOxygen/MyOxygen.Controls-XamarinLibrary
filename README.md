# MyOxygen.Controls-XamarinLibrary
A collection of useful cross-platform controls designed for Xamarin.Forms that are either not provided by Xamarin, and/or will make development quicker.

## Purpose

The idea is that Xamarin.Forms lacks some generic controls, due to controls on some platforms not conforming to guidelines on other platforms. The purpose of this collection is to facilitate code development across all Xamarin.Forms projects, and to avoid having to create the same views and controls across many apps. It is also much better for management purposes to have one code-base for commonly used controls, than have mutliple projects implementing the same control over and over again.

This library is **not** designed for customer-/project-specific designs (for example, a purple button with orange text). These should be kept with their respective projects, and should not be brought into this library.

## Testing

For every change and/or new control added to this library, it can be tested by adding it to the [NugetTester](https://github.com/MyOxygen/NugetTester-XamarinLibraryTester). If it doesn't work in **NugetTester**, it won't work in any other project.

## Controls

To access these controls from a XAML file, the `ContentView`/`ContentPage` must be initialised with:
```xaml
...
xmlns:moControls="clr-namespace:MyOxygen.Controls;assembly=MyOxygen.Controls"
...
```

To access these controls from a C# file, the file must use the library like so:
```c#
using MyOxygen.Controls;
```


### Arrow Indicator

The arrow indicator is simply an image designed to indicate to the user that tapping on the view will take the user to a new page/screen/layout. Minimal initialisation:

```xaml
<moControls:ArrowIndicator 
    ArrowSize="Normal"
    Orientation="PointingRight"
    TintColor="Black"/>
```

```c#
ArrowIndicator arrowIndicator = new ArrowIndicator()
{
    ArrowSize = ArrowIndicator.SizeEnum.Normal,
    Orientation = ArrowIndicator.OrientationEnum.PointingRight,
    TintColor = Color.Black
};
```

The above example will produce a basic black arrow icon pointing to the right. The main properties that can be accessed are:
- `ArrowSize`
  - Sets the size of the arrow with `Smaller`, `Normal` (default), and `Larger`. If specific numbers are required, use `HeightRequest` and `WidthRequest` instead.
- `Orientation`
  - Sets the orientation of the arrow. Currently only `PointingLeft` (default), `PointingUp`, `PointingRight`, and `PointingDown`.
- `TintColor`
  - Sets the colour of the arrow icon.

These properties are **not** bindable.

### Checkbox

The checkbox is basic control to allow the same checkbox layout, andimation, and feel on both Android and iOS. It is usually used to show in place of a `Switch`, and is more commonly used with web designers. Minimal initialisation:

```xaml
<moControls:Checkbox 
    CheckBoxColor="Black"
    Text="I accept the Terms and Conditions"/>
```

```c#
Checkbox checkbox = new Checkbox()
{
    CheckBoxColor = Color.Black,
    Text = "I accept the Terms and Conditions"
};
```

The above example will produce a basic black checkbox with no text. The main properties that can be accessed are:
- `CheckBoxColor`
  - Sets the colour of the checkbox for when it is both ticked and unticked. Default is Black.
- `Command`
  - Bindable property to set the `Command` for when the checkbox is tapped. 
- `CommandParameter`
  - Parameter for the `Command`.
- `IsChecked`
  - Boolean property returning whether the checkbox is ticked or unticked.
- `FormattedText`
  - Text that has been formatted to contain words of different colour/size/tap handlers/decorations/etc to appear beside the checkbox.
- `Text`
  - Basic plain text to appear beside the checkbox.
- `TextPosition`
  - Sets the position of the text relative to the checkbox itself. Currently only `ToTheRight` (default), `Below`, `ToTheLeft`, and `Above`.

These properties are all bindable. If both `FormattedText` and `Text` are empty (ie no text is given), the checkbox will be displayed on its own without any gap left for the text. When text is readded, the checkbox will reposition itself accordingly.


### Circle View

The circle view is simply a box view with rounded corners to look like a circle. Minimal initialisation:

```xaml
<moControls:CircleView 
    Color="Black"
    Radius="10"/>
```

```c#
CircleView circleView = new CircleView()
{
    Color = Color.Black,
    Radius = 10
};
```

The above example will produce a basic black circle. The main property that can be accessed is:
- `Radius`
  - Sets the radius of the circle. Default is 10 units.

This property is bindable.



### Static Label

The static label is a fix to numerous instances where Xamarin.Forms users have reported that the text alignment would default randomly to the start. This issue is still visible in v3.4.0 of Xamarin.Forms. This control fixes this issue permanently, and can be used just like the standard Xamarin.Forms `Label`. Minimal initialisation:

```xaml
<moControls:StaticLabel />
```

```c#
StaticLabel staticLabel = new StaticLabel();
```


### Tinted Image

The tinted image is an extension to the Xamarin.Forms `Image` control, but allows overlaying the image with a specific colour. This is mainly used for icons and other mono-chrome images. Minimal initialisation:

```xaml
<moControls:TintedImage
    Source="myToolbarIcon"
    TintColor="White"/>
```

```c#
TintedImage tintedImage = new TintedImage()
{
    Source = ImageSource.FromFile("myToolbarIcon"),
    TintColor = Color.White
};
```

The above example will display `myToolbarIcon` with a white overlay. The main property that can be accessed is:
- `TintColor`
  - Sets the colour of the arrow icon.

This property is bindable.

