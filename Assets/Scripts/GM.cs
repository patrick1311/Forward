using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public TileManager tileManager;
    public ObstacleManager obstacleManager;
    public ScoreManager scoreManager;
    public GUIManager guiManager;
    public PlayerMovement playerMovement;
    private GameObject player;
    private Transform camera;
    private float speed = 12f;
    private readonly float speedGrowth = 0.05f;
    private readonly float speedCap = 12.0f;
    private bool endRun;
    public float skyboxSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        endRun = false;
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxSpeed);
        if(!endRun)
        {
            tileManager.MoveBack(speed);
            obstacleManager.MoveBack(speed);

            if (player.transform.position.z > tileManager.GetSafeZone())
            {
                //Increase score by 1
                scoreManager.IncreaseScore();

                //Respawn GameObject to starting position
                tileManager.SpawnTile();
                //spawn 1-3 obstacles on each tile 
                obstacleManager.SpawnMulObstacles(Mathf.Abs(Random.Range(1, 4)), tileManager.GetNewTilePosZ());
                tileManager.DestroyTile();

                if (speed < speedCap)
                {
                   // UpDifficulty();
                }
            }

            //delete GameObject if they are in the safe zone (out of player view)
            while (obstacleManager.CanBeDeleted(camera.position.z - tileManager.GetTileLength()))
            {
                obstacleManager.DestroyObstacle();
            }
        }
    }

    void UpDifficulty()
    {
        speed += speedGrowth;
        player.GetComponent<PlayerMovement>().SetPlayerSpeed(speed);
    }

    public void EndRun()
    {
        endRun = true;
        int highscore = scoreManager.GetScore();
        if(highscore > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", highscore);
            //display some gz highscore animation
        }

        guiManager.ActiveEndMenu();
    }

    public bool IsEnded()
    {
        return endRun;
    }
}
