using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreMenu : MonoBehaviour
{
    public Text score;

    void Update()
    {
        score.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

}
