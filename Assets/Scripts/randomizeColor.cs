using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when egg spawns, material randomizes
public class randomizeColor : MonoBehaviour
{
    public List<Material> _shellList;
    
    public Material _rareShell;
    [SerializeField] private int _rarityPercent; // chance out of a hundred
    
    void Start()
    {
        // check to see if it's a special one
        var rareCheck = Random.Range(0, 100);
        if (rareCheck <= _rarityPercent)
        {
            gameObject.GetComponent<MeshRenderer>().material = _rareShell;
        }
        else // otherwise change color to one of the regular ones
        {
            var index = Random.Range(0, _shellList.Count);
            this.GetComponent<eggCrack>().eggColorIndex = index;
            gameObject.GetComponent<MeshRenderer>().material = _shellList[index];
        }
    }
}
