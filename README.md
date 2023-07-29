# ButtonAlphaChange

ButtonAlphaChange is a Unity script that enables fading alpha transitions for a button or UI element in response to different interactions.

## Features

- Smooth alpha transitions when the button is interacted with.
- Supports normal, highlighted, pressed, and disabled alpha states.
- Configurable fade duration for the alpha transitions.
- Provides an option to enable or disable the button's interactivity.

## How to Use

1. Attach the `ButtonAlphaChange` script to your button or UI element in Unity.
2. Set the desired alpha values for normal, highlighted, pressed, and disabled states in the Inspector.
3. Optionally, adjust the fade duration for smooth alpha transitions.
4. If needed, you can disable the button's interactivity by setting the `Interactable` property to `false`.

## Example

```csharp
using UnityEngine;

public class ExampleController : MonoBehaviour
{
    [SerializeField] private ButtonAlphaChange buttonAlphaChange;

    public void DisableButtonInteraction()
    {
        buttonAlphaChange.Interactable = false;
    }

    public void EnableButtonInteraction()
    {
        buttonAlphaChange.Interactable = true;
    }
}
