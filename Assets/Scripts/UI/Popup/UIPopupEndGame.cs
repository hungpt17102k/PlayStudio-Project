using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPopupEndGame : BasePopup
{
    [Header("Component")]
    [SerializeField] private TMP_Text scoreTxt;

    public override void Open(object obj = null)
    {
        base.Open(obj);

        scoreTxt.text = $"Your score: {GamePlay.Instance.Score}";
    }

    public void OnRestart()
    {
        GamePlay.Instance.StartGame();
    }
}
