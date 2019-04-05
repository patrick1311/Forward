using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text score;

    void Update()
    {
        score.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
