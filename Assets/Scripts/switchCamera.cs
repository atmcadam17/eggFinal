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
    [SerializeField] private GameObject _canvas = null;
    
    void Start()
    {
        _mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        _canvas.SetActive(false);
        _newCam.enabled = false;
        _mainCam.enabled = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _newCam.enabled = true;
            _mainCam.enabled = false;
            
            if (_canvas != null)
            {
                _canvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _mainCam.enabled = true;
            _newCam.enabled = false;
            
            if (_canvas != null)
            {
                _canvas.SetActive(false);
            }
        }
    }
}
