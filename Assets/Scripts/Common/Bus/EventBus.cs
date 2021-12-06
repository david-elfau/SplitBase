using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus
{
    private static EventBus _instance;
    public static EventBus Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventBus();
                _instance.Init();
            }
            return _instance;
        }        
    }

    private Dictionary<EventName, UnityEvent<ParameterBusObject>> eventDictionary;

    void Init()
    {
        _instance = this;
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<EventName, UnityEvent<ParameterBusObject>>();
        }
        Debug.Log("EventBus Init");
    }

    public void TriggerEvent(EventName eventName, ParameterBusObject parameterObject)
    {
        UnityEvent<ParameterBusObject> thisEvent;
        if (_instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(parameterObject);
        }
    }

    public void StartListening(EventName eventName, UnityAction<ParameterBusObject> action)
    {
        UnityEvent<ParameterBusObject> thisEvent;
        if (_instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(action);
        }
        else
        {
            thisEvent = new UnityEvent<ParameterBusObject>();
            thisEvent.AddListener(action);
            _instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public void StopListening(EventName eventName, UnityAction<ParameterBusObject> listener)
    {
        UnityEvent<ParameterBusObject> thisEvent = null;
        if (_instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }
}
