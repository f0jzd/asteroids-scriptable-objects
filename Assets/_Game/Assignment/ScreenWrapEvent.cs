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
    
    // Start is called before the first frame update
    void Start()
    {

        _Renderer = GetComponentInChildren<Renderer>();
    }
    // Update is called once per frame
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

    private void OnBecameInvisible()
    {
        onLeaveScreen.Raise(transform);
        Debug.Log("Ship is not visible");
    }

    private void OnBecameVisible()
    {
        Debug.Log("ship is visible");
    }
}
