using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ScriptableEvents;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ScreenWrapEvent : MonoBehaviour
{

    
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
            Debug.Log("ship is visible");
        }
        else
        {
            Debug.Log("Ship is not visible");
        }
    }
}
