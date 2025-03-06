using UnityEngine;

public abstract class PickItem : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer sprite;

    public virtual void Set()
    {

    }

    public void OnPointClick()
    {
        if(GamePlay.Instance.PlayerPickCurrent <= 0)
        {
            Debug.Log("No pick left");
            return;
        }

        GamePlay.Instance.PlayerPickCurrent--;

        Picked();
    }

    protected abstract void Picked();
}
