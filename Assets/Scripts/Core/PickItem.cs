using com.homemade.pattern.observer;
using UnityEngine;

public abstract class PickItem : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] protected SpriteRenderer sprite;

    [SerializeField] protected FloatingText floatingTxt;

    protected bool isPicked;

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

        if(isPicked)
        {
            Debug.Log("It's picked");
            return;
        }

        GamePlay.Instance.PlayerPickCurrent--;

        isPicked = true;
        Picked();

        this.PostEvent(EventID.Pick_Update);

        if(GamePlay.Instance.PlayerPickCurrent <= 0)
        {
            GamePlay.Instance.EndGame();
        }
    }

    protected abstract void Picked();
}
