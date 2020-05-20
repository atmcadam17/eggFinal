using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// creates an object pool the length of _eggList
// includes a SpawnEgg function
[RequireComponent(typeof(Rigidbody))]
public class eggObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _eggList;
    [SerializeField] private List<GameObject> _usedEggs = new List<GameObject>();
    [SerializeField] private GameObject _eggPrefab;
    
    void Start()
    {
        for (int i = 0; i < _eggList.Count; i++)
        {
            var newEgg = Instantiate(_eggPrefab);
            newEgg.transform.position = gameObject.transform.position;
            newEgg.SetActive(false); // makes it so the eggs dont move before theyre spawned
            
            _eggList[i] = newEgg;
        }
    }

    
    void Update()
    {
        // press semicolon to spit out an egg
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            var playerPos = GameObject.FindWithTag("Player").transform.position;
            playerPos.y += 3.2f;
            
            SpawnEgg(playerPos);
        }
    }

    // does all the egg spawning stuff automatically - use instead of instantiate
    // removes egg from _eggList and adds it to _usedEggs
    public GameObject SpawnEgg(Vector3 pos)
    {
        if (_eggList.Count > 0)
        {
            // pick a random egg
            var eggIndex = Random.Range(0, _eggList.Count);
            var newEgg = _eggList[eggIndex];
        
            // do the actual "spawning" stuff ! move it & turn kinematic off
            _eggList[eggIndex].transform.position = pos;
            _eggList[eggIndex].SetActive(true);
            
            // switch which list the egg is on
            _usedEggs.Add(_eggList[eggIndex]);
            _eggList.Remove(_eggList[eggIndex]);
            
            // returns the egg
            return newEgg;
        }
        else
        {
            Debug.Log("out of eggs");
            return null;
        }
    }

    public void DestroyEgg(GameObject egg)
    {
        _usedEggs.Remove(egg);
        egg.gameObject.SetActive(false);
    }
}
