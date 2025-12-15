# Card System

This is a flexible card system for Unity.

## How to Use

### 1. Creating a New Card

To create a new card, right-click in the Project window and go to `Create > Card`. This will create a new `Card` asset.

### 2. Customizing a Card

You can customize the card's attributes in the Inspector window.

- **Name:** The name of the card.
- **Description:** A brief description of the card's effect.
- **Attack:** The attack power of the card.
- **Defense:** The defense power of the card.
- **Category:** The category of the card (e.g., Attack, Defense, Magic, Support).
- **Consequences:** A list of consequences that will be applied when the card is played.

### 3. Creating a New Consequence

To create a new consequence, you need to create a new C# script that inherits from the `Consequence` class. You can then implement the `ApplyConsequence` method to define the custom behavior of the consequence.

Here is an example of a simple consequence that deals damage to a target:

```csharp
using UnityEngine;

public class DamageTargetConsequence : Consequence
{
    public int damageAmount;

    public override void ApplyConsequence(GameObject target)
    {
        // Check if the target has a component that can receive damage
        var damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);
        }
    }
}
```

### 4. Applying Card Effects

To apply the effects of a card, you can use the `Effect` script. Attach this script to a GameObject in your scene and call the `ApplyCardEffects` method, passing the card and the target as parameters.
