using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GM GameManager;
    public int totalObstacles = 20;
    private int typesOfObstacle;
    private List<GameObject> activeObstacle;

    void Start()
    {
        typesOfObstacle = ObjectPooler.Instance.GetObstacleTypes();
        activeObstacle = new List<GameObject>();
    }

    public void MoveBack(float backwardSpeed)
    {
        for(int i = 0; i < activeObstacle.Count; i++)
        {
            activeObstacle[i].transform.Translate(-Vector3.forward * Time.deltaTime * backwardSpeed);
        }
    }

    public void SpawnObstacle(float tileZPos)
    {
        string name;
        int xPos = Random.Range(-2, 3);

        if (Random.Range(0, 2) % typesOfObstacle == 0)
            name = "Tree";
        else
            name = "Rock";

        GameObject obj = ObjectPooler.Instance.GetPooledObject(name);
        obj.transform.position = new Vector3(xPos, 1, tileZPos);
        activeObstacle.Add(obj);
    }

    public void DestroyObstacle()
    {
        ObjectPooler.Instance.ReturnPooledObject(activeObstacle[0]);
        activeObstacle.RemoveAt(0);
    }

    public bool CanBeDeleted(float playerPosZ)
    {
        if (activeObstacle.Count <= 2)
            return false;
        return playerPosZ > activeObstacle[2].transform.position.z;
    }
}
