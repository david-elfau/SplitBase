using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Battle", order = 2)]
public class BattleScriptableObject : ScriptableObject
{
    [Serializable]
    public struct Node
    {
        public Vector2 Position;
        public int InitialPower;
        public float GrowSpeed;
        public PlayerScriptableObject Player;
    }

    public List<Node> NodeList = new List<Node>();
    public int GoldReward;

    }
