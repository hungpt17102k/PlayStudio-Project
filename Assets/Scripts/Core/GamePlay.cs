using System.Collections.Generic;
using UnityEngine;
using com.homemade.pattern.singleton;

public class GamePlay : MonoSingleton<GamePlay>
{
    [Header("Player info")]
    [SerializeField] private int playerPickCount;
    [SerializeField] private int score;

    [Header("Picker Info")]
    [SerializeField] private Transform pickerHolder;

    [SerializeField] private Vector2 grid;
    [SerializeField] private Vector2 spacing;

    [Header("Random list")]
    [SerializeField] private WeightedRandomList<PickItem> pickerRandomList;

    private List<PickItem> pickItems = new List<PickItem>();

    private int playerPickCurrent = 0;
    public int PlayerPickCurrent
    {
        get => playerPickCurrent;
        set => playerPickCurrent = value;
    }

    public int Score
    {
        get => score;
        set => score = value;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        playerPickCurrent = playerPickCount;

        CreatePicker();
    }

    private void CreatePicker()
    {
        pickItems.Clear();
        DeletePicker();

        Vector2 startPos = new Vector2(-5f, 1.5f);
        Vector2 pos = startPos;

        for(int x = 0; x < grid.x; x++)
        {
            for(int y = 0; y < grid.y; y++)
            {
                var picker = Instantiate(pickerRandomList.GetRandom(), pickerHolder);
                pickItems.Add(picker);
                picker.Set();

                pos = startPos + new Vector2(x, y) * spacing;
                picker.transform.localPosition = pos;
            }
        }
    }

    private void DeletePicker()
    {
        if (pickerHolder.childCount <= 0) return;

        for(int i = pickerHolder.childCount - 1; i >= 0; i--)
        {
            Destroy(pickerHolder.GetChild(i).gameObject);
        }    
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartGame();
        }
    }
}
