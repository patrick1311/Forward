using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    //public GameObject[] tiles;
    private Transform player;
    private int tilesOnScreen = 10;
    private int tileLength = 5;
    private float speed = 3.0f;
    private List<GameObject> activeTiles;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

        int spawnPos = 0;
        for (int i = 0; i < tilesOnScreen; i++)
        {
            GameObject obj = ObjectPooler.Instance.GetPooledObject("Tile");
            obj.transform.position = new Vector3(0, 0, spawnPos);
            //set newly spawned tile to be ObjectPool children
            obj.transform.SetParent(ObjectPooler.Instance.transform);
            spawnPos += tileLength;
            activeTiles.Add(obj);
        }

    }

    public void moveTiles(float s)
    {

    }

    void Update()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            activeTiles[i].transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }

        if (player.position.z > activeTiles[2].transform.position.z)
        {
            SpawnTile();
            DestroyTile();
        }
        /*
        if (player.position.z > (spawnPos - tileLength * (tilesOnScreen - 2)))
        {
            DestroyTile();
            SpawnTile();
            count++;
        }*/

    }

    private void SpawnTile()
    {
        GameObject obj = ObjectPooler.Instance.GetPooledObject("Tile");
        //set position of new tile to be at the last tile in the activeTiles[] list
        obj.transform.position = new Vector3(0, 0, activeTiles[tilesOnScreen-1].transform.position.z + tileLength);
        //set newly spawned tile to be ObjectPool children
        obj.transform.SetParent(ObjectPooler.Instance.transform);
        activeTiles.Add(obj);
    }

    private void DestroyTile()
    {
        //put back "destroyed" object into ObjectPool
        ObjectPooler.Instance.ReturnPooledObject(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
