using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour

{
    private List<PoolObject> pool;

    public void Initialize(PoolObject GameObjectPrefab, int poolSize)
    {
        pool = new List<PoolObject>();
        for (int i = 0; i < poolSize; i++)
        {
            PoolObject poolObject = Instantiate(GameObjectPrefab, this.transform).GetComponent<PoolObject>();
            
            poolObject.Initialize();
            //TODO CREATE BUNCH OF UNITS
            pool.Add(poolObject);
        }
    }

    public void UpdatePool()
    {
        foreach(PoolObject obj in pool)
        {
            obj.UpdatePoolObject();
        }
    }

    public PoolObject GetFreeObject()
    {
        foreach (PoolObject obj in pool)
        {
            if (obj.LifeCycle.GetCurrentStatus() == ObjectLifeCycle.Status.paused)
            {
                return obj;
            }
        }
        return null;
    }
}