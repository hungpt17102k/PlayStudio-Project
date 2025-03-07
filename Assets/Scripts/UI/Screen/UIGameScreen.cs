using com.homemade.pattern.observer;
using TMPro;
using UnityEngine;

public class UIGameScreen : BaseScreen
{
    [Header("Component")]
    [SerializeField] private TMP_Text pickTxt;
    [SerializeField] private TMP_Text scoreTxt;

    [Header("Buy pick")]
    [SerializeField] private TMP_Text buyTxt;
    [SerializeField] private int scoreToBuy;

    private void Awake()
    {
        this.RegisterListener(EventID.StartGame, OnStartGame);
        this.RegisterListener(EventID.Pick_Update, OnPickUpdate);
        this.RegisterListener(EventID.Score_Update, OnScoreUpdate);
    }

    private void Start()
    {
        OnPickUpdate(null);
        OnScoreUpdate(null);

        buyTxt.text = $"1P = {scoreToBuy}";
    }

    private void OnStartGame(object obj)
    {
        pickTxt.text = $"You have {GamePlay.Instance.PlayerPickCurrent} pick";
        scoreTxt.text = $"{GamePlay.Instance.Score}";
    }

    private void OnPickUpdate(object obj)
    {
        pickTxt.text = $"You have {GamePlay.Instance.PlayerPickCurrent} pick";
    }

    private void OnScoreUpdate(object obj)
    {
        scoreTxt.text = $"{GamePlay.Instance.Score}";
    }

    public void OnBuy()
    {
        if(GamePlay.Instance.Score < scoreToBuy)
        {
            Debug.Log("Not enough money");
            return;
        }

        GamePlay.Instance.Score -= scoreToBuy;

        GamePlay.Instance.PlayerPickCurrent++;

        this.PostEvent(EventID.Score_Update);
        this.PostEvent(EventID.Pick_Update);
    }
}
