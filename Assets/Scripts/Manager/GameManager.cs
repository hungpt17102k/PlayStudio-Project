using com.homemade.pattern.singleton;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private readonly string userScore = "User_Score";

    private async void Start()
    {
        UIManager.Instance.ShowLoading();

        // Load data
        GamePlay.Instance.Score = LoadScore();
        await UniTask.DelayFrame(1);

        // Show UI
        UIManager.Instance.ShowScreen<UIGameScreen>();
        await UniTask.WaitForSeconds(1f);

        UIManager.Instance.HideLoading();

    }

    public int LoadScore()
    {
        return PlayerPrefs.GetInt(userScore, 0);
    }

    public void SaveScore(int value)
    {
        PlayerPrefs.SetInt(userScore, value);
    }

}
