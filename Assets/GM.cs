using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public TileManager tileManager;
    public ObstacleManager obstacleManager;
    private Transform player;
    private readonly float speed = 5.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        tileManager.MoveBack(speed);
        obstacleManager.MoveBack(speed);

        //Respawn GameObject to starting position
        if (player.position.z > tileManager.GetSafeZone())
        {
            tileManager.SpawnTile();
            obstacleManager.SpawnObstacle(tileManager.GetNewTilePosition());
            tileManager.DestroyTile();
        }

        //delete obstacle if it is in the safe zone (out of player view)
        if(obstacleManager.CanBeDeleted(player.position.z))
        {
            obstacleManager.DestroyObstacle();
        }
    }

}
