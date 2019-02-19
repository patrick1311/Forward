using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public TileManager tileManager;
    public ObstacleManager obstacleManager;
    private Transform camera;
    private Transform player;
    private readonly float speed = 10.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        tileManager.MoveBack(speed);
        obstacleManager.MoveBack(speed);

        //Respawn GameObject to starting position
        if (player.position.z > tileManager.GetSafeZone())
        {
            tileManager.SpawnTile();
            SpawnObstacles(Random.Range(1, 3)); //spawn 1 or 2 obstacles on each tile
            tileManager.DestroyTile();
        }

        //delete obstacle if it is in the safe zone (out of player view)
        while(obstacleManager.CanBeDeleted(camera.position.z))
        {
            obstacleManager.DestroyObstacle();
        }
    }

    void SpawnObstacles(int amount)
    {
        while(amount > 0)
        {
            obstacleManager.SpawnObstacle(tileManager.GetNewTilePosition());
            amount--;
        }
    }

}
