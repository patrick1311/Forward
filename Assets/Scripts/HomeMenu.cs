using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("RunScene");
    }
}
