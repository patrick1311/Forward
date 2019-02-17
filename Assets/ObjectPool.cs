using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool current;
    private List<GameObject> pool;
    public GameObject type;
    public int amount;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        pool = new List<GameObject>();
       
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(type) as GameObject;
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        GameObject obj = Instantiate(type) as GameObject;
        pool.Add(obj);
        return obj;

    }

    public int PoolCount()
    {
        return pool.Count;
    }
}
