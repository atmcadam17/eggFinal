using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when egg spawns, material randomizes
public class randomizeColor : MonoBehaviour
{
    [SerializeField] private List<Material> _shellList;
    
    [SerializeField] private Material _rareShell;
    [SerializeField] private int _rarityPercent; // chance out of a hundred
    
    void Start()
    {
        // check to see if it's a special one
        var rareCheck = Random.Range(0, 100);
        if (rareCheck <= _rarityPercent)
        {
            gameObject.GetComponent<MeshRenderer>().material = _rareShell;
        }
        else
        {
            var newColor = Random.Range(0, _shellList.Count);
            gameObject.GetComponent<MeshRenderer>().material = _shellList[newColor];
        }
    }
}
