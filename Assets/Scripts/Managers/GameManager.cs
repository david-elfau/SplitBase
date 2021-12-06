using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericManager
{

    public override void Initialize()
    {
        RegisterEvents();
        initializated = true;
    }

    public override void RegisterEvents()
    {
    }

    public override void UnregisterEvents()
    {
    }
}
