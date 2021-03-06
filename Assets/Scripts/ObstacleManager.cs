﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public int totalObstacles = 20;
    private int typesOfObstacle;
    private List<GameObject> activeObstacle;
    private List<int> numObstacleOnTile;

    void Start()
    {
        typesOfObstacle = ObjectPooler.Instance.GetObstacleTypes();
        activeObstacle = new List<GameObject>();
        numObstacleOnTile = new List<int>();
    }

    public void MoveBack(float backwardSpeed)
    {
        for(int i = 0; i < activeObstacle.Count; i++)
        {
            //move obstacle in -z direction based on world space regardless of object rotation
            activeObstacle[i].transform.Translate(-Vector3.forward * Time.deltaTime * backwardSpeed, Space.World);
        }
    }

    public void SpawnObstacle(Vector3 spawnPos)
    {
        GameObject obj = null;

        int randObstacle = Mathf.Abs(Random.Range(0, typesOfObstacle));
        switch(randObstacle)
        {
            case 0:
                obj = ObjectPooler.Instance.GetPooledObject("Tree");
                break;
            case 1:
                obj = ObjectPooler.Instance.GetPooledObject("Rock1");
                break;
            case 2:
                obj = ObjectPooler.Instance.GetPooledObject("Rock2");
                break;
            case 3:
                obj = ObjectPooler.Instance.GetPooledObject("Rock3");
                break;
            default:
                Debug.Log("Error in generating random obstacles.");
                break;
        }/*
        if (Random.Range(0, typesOfObstacle))
            obj = ObjectPooler.Instance.GetPooledObject("Tree");
        else
            obj = ObjectPooler.Instance.GetPooledObject("Rock");
            */
        obj.transform.rotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
        obj.transform.position = spawnPos;
        activeObstacle.Add(obj);
    }

    public void SpawnMulObstacles(int amount, float tilePosZ)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-2, 3), 1, tilePosZ);
        List<Vector3> occupiedPos = new List<Vector3>();

        while(amount > 0)
        {
            if(SafeToSpawn(occupiedPos, spawnPos))
            {
                SpawnObstacle(spawnPos);
                occupiedPos.Add(spawnPos);
                amount--;
            }
            else
            {
                spawnPos.x = Random.Range(-2, 3);
            }
        }
    }

    public void DestroyObstacle()
    {
        ObjectPooler.Instance.ReturnPooledObject(activeObstacle[0]);
        activeObstacle.RemoveAt(0);
    }

    bool SafeToSpawn(List<Vector3> occupiedPos, Vector3 pos)
    {
        for(int i = 0; i < occupiedPos.Count; i++)
        {
            if (occupiedPos[i] == pos)
                return false;
        }
        return true;
    }

    public bool CanBeDeleted(float cameraPosZ)
    {
        if (activeObstacle.Count < 1)
            return false;
        return cameraPosZ > activeObstacle[0].transform.position.z;
    }
}
