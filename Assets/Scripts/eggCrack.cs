using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// makes the egg break when it hits a surface with a high enough magnitude
public class eggCrack : MonoBehaviour
{
    private Rigidbody _rb;
    private float _magnitude;
    public int eggColorIndex;
    private eggObjectPool _eggPool;

    [SerializeField] private GameObject _brokenEggPrefab; // spawns when egg cracks
    [SerializeField] private float _magnitudeThreshold; // how high magnitude has to be to make egg crack
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _eggPool = GameObject.Find("eggObjectPool").GetComponent<eggObjectPool>();
    }

    private void FixedUpdate()
    {
        _magnitude = _rb.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_magnitude >= _magnitudeThreshold && !other.gameObject.CompareTag("Player"))
        {
            Crack();
        }
    }

    // when the egg cracks, replace it with a broken egg version and destroy this object
    public void Crack()
    {
        // create a new broken egg with same color shell
        var newCrackedEgg = Instantiate(_brokenEggPrefab);
        
        // move it to the right location
        newCrackedEgg.transform.position = this.transform.position;
        
        // "destroy" this egg (but not really because it's in the object pool)
        _eggPool.DestroyEgg(this.gameObject);
    }
}
