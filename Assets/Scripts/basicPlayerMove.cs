using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// basic controls to make the player walk around

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class basicPlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = .1f;
    [SerializeField] private float _turnspeed = 2;

    private float _currentMoveSpeed = 0;
    private float _currentTurnSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _currentMoveSpeed = _moveSpeed;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _currentMoveSpeed = -_moveSpeed;
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _currentTurnSpeed = _turnspeed;
        }
        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            //transform.eulerAngles += new Vector3(0,-_turnspeed,0);
            _currentTurnSpeed = -_turnspeed;
        }

        if (Input.GetKey(KeyCode.None))
        {
            _currentMoveSpeed = 0;
            _currentTurnSpeed = 0;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        _currentMoveSpeed = 0;
        _currentTurnSpeed = 0;
    }

    private void FixedUpdate()
    {
        this.transform.Translate(new Vector3(0,0,_currentMoveSpeed));
        this.transform.eulerAngles += new Vector3(0, _currentTurnSpeed, 0);
        //this.transform.Rotate(new Vector3(0, _currentTurnSpeed, 0));
    }
}
