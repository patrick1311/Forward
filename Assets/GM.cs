using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public TileManager tileManager;
    public ObstacleManager obstacleManager;
    public ScoreManager scoreManager;
    private GameObject player;
    private Transform camera;
    //private Transform player;
    private float speed = 10.0f;
    private bool endGame = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
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
            obstacleManager.SpawnMulObstacles(Mathf.Abs(Random.Range(1, 3)), tileManager.GetNewTilePosZ());
            tileManager.DestroyTile();
        }
        
        //delete GameObject if they are in the safe zone (out of player view)
        while(obstacleManager.CanBeDeleted(camera.position.z))
        {
            obstacleManager.DestroyObstacle();
        }
    }

    public void EndGame()
    {
        speed = 0;
    }

}
