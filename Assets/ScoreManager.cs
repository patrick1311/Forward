using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score;

    void Start()
    {
        scoreText.text = "0";
        score = 0;
    }

    public void IncreaseScore(int increaseAmount = 1)
    {
        score += increaseAmount;
        scoreText.text = score.ToString();
    }
}
