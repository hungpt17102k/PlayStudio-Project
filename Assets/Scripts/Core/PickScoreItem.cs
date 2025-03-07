using com.homemade.pattern.observer;
using Lean.Pool;
using UnityEngine;

public class PickScoreItem : PickItem
{
    [Header("Score")]
    [SerializeField] private Vector2 scoreRange;

    private int score;

    public override void Set()
    {
        base.Set();

        score = (int) Random.Range(scoreRange.x, scoreRange.y);
    }

    protected override void Picked()
    {
        GamePlay.Instance.Score += score;

        // Show effect
        sprite.color = Color.green;
        LeanPool.Spawn(floatingTxt, transform.position, Quaternion.identity).ShowText($"+{score}");

        GameManager.Instance.SaveScore(GamePlay.Instance.Score);
        this.PostEvent(EventID.Score_Update);
    }
}
