using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// basic script to make camera follow player
// not being used currently

[RequireComponent(typeof(Camera))]

public class cameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}