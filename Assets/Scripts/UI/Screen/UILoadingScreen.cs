using System;
using System.Collections;
using UnityEngine;

public class UILoadingScreen : BaseScreen
{
    [SerializeField] private GameObject content;

    public void Loading(Action onLoad = null)
    {
        // Loading show and animation
        StartCoroutine(LoadingCoroutine(onLoad));
    }

    private IEnumerator LoadingCoroutine(Action onLoad)
    {
        content.SetActive(true);
        yield return new WaitForEndOfFrame();

        onLoad?.Invoke();
    }

    public void HideLoading()
    {
        // Animation for hide loading
        content.SetActive(false);
    }
}
