using Lean.Pool;
using UnityEngine;

public class PickSelectItem : PickItem
{
    [Header("Select")]
    [SerializeField] private int selectAdd = 1;

    public override void Set()
    {
        base.Set();


    }

    protected override void Picked()
    {
        GamePlay.Instance.PlayerPickCurrent += selectAdd;
        sprite.color = Color.red;

        // Show effect
        LeanPool.Spawn(floatingTxt, transform.position, Quaternion.identity).ShowText("+1 pick");

    }
}
