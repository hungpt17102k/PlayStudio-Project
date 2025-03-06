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

        sprite.color = Color.green;

        GameManager.Instance.SaveScore(GamePlay.Instance.Score);
    }
}
