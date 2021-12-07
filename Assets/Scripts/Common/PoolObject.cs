using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{

    public ObjectLifeCycle LifeCycle = new ObjectLifeCycle();

    public abstract void Initialize();

    public abstract void UpdatePoolObject();
    public virtual void EnablePoolObject()
    {
        gameObject.SetActive(true);
        LifeCycle.Play();
    }
    
    public virtual void DisablePoolObject()
    {
        gameObject.SetActive(false);
        LifeCycle.Pause();
    }


}