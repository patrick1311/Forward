﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public TileManager tileManager;
    public ObstacleManager obstacleManager;
    public Text score;
    private Transform camera;
    private Transform player;
    private readonly float speed = 10.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        score.text = "0";
    }

    void Update()
    {
        tileManager.MoveBack(speed);
        obstacleManager.MoveBack(speed);

        //Respawn GameObject to starting position
        if (player.position.z > tileManager.GetSafeZone())
        {
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

}
