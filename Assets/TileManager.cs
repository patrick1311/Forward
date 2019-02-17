using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;
    private Transform player;
    private int spawnPos = 0;
    private int tilesOnScreen = 5;
    private int tileLength = 4;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


        for(int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z > (spawnPos - tileLength * tilesOnScreen))
        {
            SpawnTile();
        }
    }

    private void SpawnTile()
    {
        GameObject obj = ObjectPool.current.GetPooledObject();
        Debug.Log(obj);
        //GameObject obj = Instantiate(tiles[0]) as GameObject;
        obj.SetActive(true);
        obj.transform.position = new Vector3(0, 0, spawnPos);
        //set newly spawned tile to be TileManager children
        obj.transform.SetParent(transform);
        spawnPos += tileLength;

    }
}
