using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TwoParamGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    [SerializeField] private TwoParamEvent gameEvent;
    [Tooltip("Event to register with.")]
    [SerializeField] private TwoGenericParamEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(bool state, int value)
    {
        response.Invoke(state, value);
    }
}
