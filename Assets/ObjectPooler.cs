using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //Set the configuration to be visible in the Unity inspector
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, List<GameObject>> poolDictionary;
    private GameObject currentPrefab;

    //Singleton: the instance of this script
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, List<GameObject>>();

        //Initialize all different type of GameObject pools
        foreach(Pool pool in pools)
        {
            List<GameObject> objectPool = new List<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Add(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    //return a reference to a prefab in the pool based on tag name
    public GameObject GetPooledObject(string tag)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Pool with tag " + tag + " not found!");
            return null;
        }

        for (int i = 0; i < poolDictionary[tag].Count; i++)
        {
            if (!poolDictionary[tag][i].activeInHierarchy)
            {
                poolDictionary[tag][i].SetActive(true);
                return poolDictionary[tag][i];
            }
        }

        //if no reusable object in pool, create new one
        currentPrefab = getCurrentPrefab(tag);
        GameObject obj = Instantiate(currentPrefab) as GameObject;
        poolDictionary[tag].Add(obj);
        obj.SetActive(true);
        return obj;
    }

    public void ReturnPooledObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public GameObject getCurrentPrefab(string tag)
    {
        for (int i = 0; i < pools.Count; i++)
        {
            if (pools[i].tag == tag)
            {
                return pools[i].prefab;
            }
        }

        return null;
    }
}
