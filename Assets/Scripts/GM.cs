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
    private float speed = 7.0f;
    private readonly float speedGrowth = 0.05f;
    private readonly float speedCap = 15.0f;
    private bool endRun;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        endRun = false;
    }

    void Update()
    {
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
                //spawn 1 or 2 obstacles on each tile
                obstacleManager.SpawnMulObstacles(Mathf.Abs(Random.Range(1, 4)), tileManager.GetNewTilePosZ());
                tileManager.DestroyTile();

                if (speed < speedCap)
                {
                    UpDifficulty();
                }
            }

            //delete GameObject if they are in the safe zone (out of player view)
            while (obstacleManager.CanBeDeleted(camera.position.z))
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
        guiManager.ActiveEndMenu();
    }

}
