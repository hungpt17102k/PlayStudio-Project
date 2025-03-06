using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BasePopup : MonoBehaviour, IPopup
{
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private bool useAnimator;

    [Header("First Selected Options")]
    [SerializeField] private GameObject buttonFirstSelected;

#if UNITY_EDITOR
    public virtual void OnValidate()
    {
        if (TryGetComponent<Animator>(out Animator ani))
        {
            this.animator = ani;
        }
        else
        {
            animator = gameObject.AddComponent<Animator>();
        }
    }
#endif

    public virtual void Open(object obj = null)
    {
        gameObject.SetActive(true);

        animator.enabled = useAnimator;

        SetFirstSelectedButton();
    }

    public virtual void Close()
    {
        StartCoroutine(CloseCoroutine());
    }

    private IEnumerator CloseCoroutine()
    {
        float timeClose = 0f;

        if (useAnimator)
        {
            animator.SetTrigger("Close");
            timeClose = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        }

        yield return new WaitForSeconds(timeClose);
        gameObject.SetActive(false);

        UIManager.Instance.MoveLastSiblingPopup(this.transform);
        UIManager.Instance.HidePopupBG();

        UIManager.Instance.SelectedButton();
    }

    public void DeActive()
    {
        gameObject.SetActive(false);
    }

    public void DestroyPopup()
    {
        Destroy(gameObject);
    }

    public virtual void SetFirstSelectedButton()
    {
        if (buttonFirstSelected == null) return;
        EventSystem.current.SetSelectedGameObject(buttonFirstSelected);
    }
}
