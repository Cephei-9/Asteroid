using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public static ScoreSystem SingleTone { get; private set; }
    public int Score { get; private set; }

    private void Start()
    {
        if (SingleTone != null) Debug.LogError("SingleToneExeption");
        SingleTone = this;
    }

    public void AddScore(int score)
    {
        Score += score;
        _scoreText.text = Score.ToString();
    }
}
