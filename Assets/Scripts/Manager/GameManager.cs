using com.homemade.pattern.singleton;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private readonly string userScore = "User_Score";

    private async void Start()
    {
        // Load data
        LoadScore();
        await UniTask.DelayFrame(1);

        // Show UI
        UIManager.Instance.ShowScreen<UIGameScreen>();
        await UniTask.WaitForSeconds(1f);

    }

    public void LoadScore()
    {
        PlayerPrefs.GetInt(userScore, 0);
    }

    public void SaveScore(int value)
    {
        PlayerPrefs.SetInt(userScore, value);
    }

}
