using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls the cooking of the egg
public class stoveController : MonoBehaviour
{
    private bool _stoveOn;
    [SerializeField] private ParticleSystem _burnerParticles;
    [SerializeField] private List<GameObject> _buttonList;
    [SerializeField] private Collider _cookArea;
    
    // Start is called before the first frame update
    void Start()
    {
        _stoveOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // toggle particle system on and off depending on stove
        if (_stoveOn && !_burnerParticles.GetComponent<Renderer>().enabled)
        {
            _burnerParticles.GetComponent<Renderer>().enabled = true;
        }
        else if (!_stoveOn && _burnerParticles.GetComponent<Renderer>().enabled)
        {
            _burnerParticles.GetComponent<Renderer>().enabled = false;
        }
        
        // if the player clicks one of the buttons, toggle stove on / off
        Ray myRay = new Ray();
    }
}
