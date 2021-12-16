using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterBusObject
{
    object parameterValue = null;
    // Start is called before the first frame update

    public ParameterBusObject()
    {

    }

    public ParameterBusObject(string stringParameter)
    {
        parameterValue = stringParameter;
    }
    public ParameterBusObject(int intParameter)
    {
        parameterValue = intParameter;

    }
    public ParameterBusObject(float floatParameter)
    {
        parameterValue = floatParameter;
    }
    public ParameterBusObject(Node nodeParameter)
    {
        parameterValue = nodeParameter;
    }

    public ParameterBusObject(BattleScriptableObject battleParameter)
    {
        parameterValue = battleParameter;
    }

    public string GetParameterString()
    {
        return parameterValue.ToString();
    }

    public int GetParameterInt()
    {
        try
        {
            int intValue = (int)parameterValue;
            return intValue;
        } catch (Exception)
        {
            return int.MinValue;
        }
    }

    public float GetParameterFloat()
    {
        try
        {
            float floatValue = (float)parameterValue;
            return floatValue;
        }
        catch (Exception)
        {
            return float.MinValue;
        }
    }


    public Node GetParameterNode()
    {
        try
        {
            Node nodeValue = (Node)parameterValue;
            return nodeValue;
        }
        catch (Exception)
        {
            return null;
        }

    }

    public BattleScriptableObject GetParameterBattleData()
    {
        try
        {
            BattleScriptableObject battleValue = (BattleScriptableObject)parameterValue;
            return battleValue;
        }
        catch (Exception)
        {
            return null;
        }

    }
}
