using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public GameObject homeMenu;
    public GameObject endMenu;
    public ScoreManager scoreManager;
    public Text scoreText;

    void Start()
    {
        endMenu.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ActiveEndMenu()
    {
        scoreText.text = scoreManager.GetScore().ToString();
        endMenu.SetActive(true);
    }

    public void RestartRunScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToHomeMenu()
    {
        SceneManager.LoadScene("HomeMenu");
    }
}
