using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GM GameManager;
    public int tilesOnScreen = 10;
    private readonly int tileLength = 5;
    private float speed = 3.0f;
    private List<GameObject> activeTiles;


    void Start()
    {
        activeTiles = new List<GameObject>();

        //set safe amount of tiles
        if (tilesOnScreen < 3)
            tilesOnScreen = 5;

        int spawnPos = 0;
        for (int i = 0; i < tilesOnScreen; i++)
        {
            GameObject obj = ObjectPooler.Instance.GetPooledObject("Tile");
            obj.transform.position = new Vector3(0, 0, spawnPos);
            spawnPos += tileLength;
            activeTiles.Add(obj);
        }
    }

    public void MoveBack(float backwardSpeed)
    {
        for (int i = 0; i < activeTiles.Count; i++)
        {
            activeTiles[i].transform.Translate(-Vector3.forward * Time.deltaTime * backwardSpeed);
        }
    }

    public void SpawnTile()
    {
        GameObject obj = ObjectPooler.Instance.GetPooledObject("Tile");
        //set position of new tile to be at the last tile in the activeTiles[] list
        obj.transform.position = new Vector3(0, 0, activeTiles[tilesOnScreen-1].transform.position.z + tileLength);
        activeTiles.Add(obj);
    }

    public void DestroyTile()
    {
        //put back "destroyed" object into ObjectPool
        ObjectPooler.Instance.ReturnPooledObject(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public float GetNewTilePosition()
    {
        return activeTiles[tilesOnScreen - 1].transform.position.z + tileLength;
    }

    public float GetSafeZone()
    {
        return activeTiles[2].transform.position.z;
    }
}
