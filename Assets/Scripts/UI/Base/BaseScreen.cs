using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScreen : MonoBehaviour, IScreen
{
    [Header("First Selected Options")]
    [SerializeField] protected GameObject buttonFirstSelected;

    private bool isInit = false;

    public virtual void Init()
    {
        if (isInit) return;

        isInit = true;
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);

        SetFirstSelectedButton();
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);

        UIManager.Instance.SelectedButton();
    }

    public virtual void SetFirstSelectedButton()
    {
        if (buttonFirstSelected == null) return;
        EventSystem.current.SetSelectedGameObject(buttonFirstSelected);
    }
}
