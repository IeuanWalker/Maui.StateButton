# Maui.StateButton  [![Nuget](https://img.shields.io/nuget/v/IeuanWalker.Maui.StateButton)](https://www.nuget.org/packages/IeuanWalker.Maui.StateButton) [![Nuget](https://img.shields.io/nuget/dt/IeuanWalker.Maui.StateButton)](https://www.nuget.org/packages/IeuanWalker.Maui.StateButton) 

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.StateButton.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.StateButton?ref=badge_shield)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/b4823215925c47f7a42b64bc516a6e42)](https://www.codacy.com/gh/IeuanWalker/Maui.StateButton/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=IeuanWalker/Maui.StateButton&amp;utm_campaign=Badge_Grade)

With this control you are able to create any style of button.
This is possible as it acts as a wrapper to your XAML and provides you the events/ commands and properties to bind too.

It's also _100% accessible_ with each platform seeing/ treating the control as a native button.

## How to use it?
Install the [NuGet package](https://www.nuget.org/packages/IeuanWalker.StateButton) into your shared project project
```
Install-Package IeuanWalker.StateButton
```

## What can I do with it?
### Properties
| Property | What it does | Extra info |
|---|---|---- |
| State | This changes based on the button state. i.e. `Pressed`, `NotPressed` | Default state is `NotPressed` <br/>  <br/> The binding mode is `OneWayToSource` so it can only be controlled via this control. |

### Events
| Event | What it does |
|---|---|
| Clicked | Triggerd when the button is pressed and released |
| Pressed | Triggerd when the button is pressed |
| Released | Triggerd when the button is released |

### Commands
| Command | What it does |
|---|---|
| ClickedCommand | Triggerd when the button is pressed and released |
| PressedCommand | Triggerd when the button is pressed |
| ReleasedCommand | Triggerd when the button is released |


## How to style the button for different states
Simply add a Trigger to any element and bind it to the `State` property of the button - 
```xaml
<stateButton:StateButton Padding="20,10" BackgroundColor="Red">
    <stateButton:StateButton.StrokeShape>
        <RoundRectangle CornerRadius="10" />
    </stateButton:StateButton.StrokeShape>
    <stateButton:StateButton.Triggers>
        <Trigger TargetType="stateButton:StateButton" Property="State" Value="Pressed">
            <Setter Property="BackgroundColor" Value="Green" />
        </Trigger>
    </stateButton:StateButton.Triggers>

    <Label Text="Test" TextColor="White">
        <Label.Triggers>
            <DataTrigger Binding="{Binding Source={RelativeSource AncestorType={x:Type stateButton:StateButton}}, Path=State}"
                        TargetType="Label"
                        Value="Pressed">
                <Setter Property="TextColor" Value="Blue" />
            </DataTrigger>
        </Label.Triggers>
    </Label>
</stateButton:StateButton>
```

## Accessibility
The control itself is seen as a native control on both platforms, so inherits the same accessbility attributes. So from a screenreader and keyboard POV it is a native button.

There are a few things you can do to imporve the accessibility -

Set the [`SemanticProperties.Description`](https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/accessibility#description) property on the button. Android is smart enough and if you dont set this property it will try and find a label with the control to read the text from, iOS does not do this, so if you dont set this property iOS screen reader will just announce that there is a button, but no name or context is given.

Optionally you can also set the [`SemanticProperties.Hint`](https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/accessibility#hint) property. Using this property you can give more context to what the button is for/ will do.

## Examples
| Designs from a production app | Complex example |
|------|------|
|![Production example of control](/Docs/prodExample.gif)| <p>This shows the StateButton as the wrapper for a card. When the card is pressed or clicked then the title is set to bold and the border goes darker.</p> <p> The card also shakes when clicked, this shows that it works with the [AnimationBehaviours from XamarinCommunityToolkit](https://github.com/xamarin/XamarinCommunityToolkit). </p><p> It also shows that it works with nested TapGestureRecognizer, XF native button and nested StateButton - </p> ![Complex example of control](/Docs/ComplexExample.gif)|

## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.StateButton.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FIeuanWalker%2FMaui.StateButton?ref=badge_large)
