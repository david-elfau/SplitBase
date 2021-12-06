using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericManager : MonoBehaviour
{

    public bool initializated = false;

    public abstract void Initialize();

    public abstract void RegisterEvents();
    public abstract void UnregisterEvents();
}
