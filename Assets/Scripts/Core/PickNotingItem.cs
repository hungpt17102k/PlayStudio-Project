using Lean.Pool;
using UnityEngine;

public class PickNotingItem : PickItem
{
    public override void Set()
    {
        base.Set();


    }

    protected override void Picked()
    {
        sprite.color = Color.gray;

        // Show effect
        LeanPool.Spawn(floatingTxt, transform.position, Quaternion.identity).ShowText("Nothing!");
    }
}
