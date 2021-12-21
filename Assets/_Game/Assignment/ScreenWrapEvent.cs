using System;
using ScriptableEvents;
using ScriptableEvents.GameEvents;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ScreenWrapEvent : MonoBehaviour
{
    [SerializeField] private GameEventTransform onLeaveScreen;


    private Renderer _Renderer;
    void Start()
    {
        _Renderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if (_Renderer.isVisible)
        {

        }
        else
        {
            onLeaveScreen.Raise(transform);
        }
    }
}

    
