using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public TileManager tileManager;
    public ObstacleManager obstacleManager;
    private Transform player;
    private float speed = 3.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        tileManager.MoveBack(speed);
        if (player.position.z > tileManager.GetSafeZone())
        {
            tileManager.SpawnTile();
            tileManager.DestroyTile();
        }
    }

}
