using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TwoGenericParamEvent : UnityEvent<bool, int> { }

[CreateAssetMenu(fileName = "TwoParamEvent", menuName = "Events/Two Parameters Event")]
public class TwoParamEvent : ScriptableObject
{
    private List<TwoParamGameEventListener> listeners = new List<TwoParamGameEventListener>();

    public void Raise(bool state, int value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(state, value);
        }
    }

    public void RegisterListener(TwoParamGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(TwoParamGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
