using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// switch camera when player enters collider

[RequireComponent(typeof(BoxCollider))]

public class switchCamera : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private Camera _newCam;
    
    [SerializeField] private GameObject _player;
    
    void Start()
    {
        _mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        _newCam.enabled = false;
        _mainCam.enabled = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _player)
        {
            _newCam.enabled = true;
            _mainCam.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == _player)
        {
            _mainCam.enabled = true;
            _newCam.enabled = false;
        }
    }
}
