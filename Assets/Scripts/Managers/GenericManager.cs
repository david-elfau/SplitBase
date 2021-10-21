using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericManager : MonoBehaviour
{

    public bool initializated = false;

    public virtual void Initialize()
    {
        initializated = true;
    }

    public virtual void RegisterEvents()
    {
    }
}
