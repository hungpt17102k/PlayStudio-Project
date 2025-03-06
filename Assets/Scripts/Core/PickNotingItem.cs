using UnityEngine;

public class PickNotingItem : PickItem
{
    public override void Set()
    {
        base.Set();


    }

    protected override void Picked()
    {
        sprite.color = Color.black;
    }
}
