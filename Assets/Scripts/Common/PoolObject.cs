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
        LifeCycle.Play();
    }
    
    public virtual void DisablePoolObject()
    {
        LifeCycle.Pause();
    }


}