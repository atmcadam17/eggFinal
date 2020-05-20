using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// use this script to make the broken egg inherit shell color

public class inheritColor : MonoBehaviour
{
    private List<Material> shellMats;
    [SerializeField] private List<GameObject> shells;
    private Material rareMat;
    
    // Start is called before the first frame update
    void Start()
    {
        shellMats = GameObject.FindObjectOfType<randomizeColor>()._shellList;
        rareMat = GameObject.FindObjectOfType<randomizeColor>()._rareShell;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InheritColor(int colorIndex)
    {
        for (int i = 0; i < shells.Count - 1; i++)
        {
            if (colorIndex >= 0 && colorIndex <= shellMats.Count)
            {
                shells[i].GetComponent<MeshRenderer>().material = shellMats[colorIndex];
            }
            else
            {
                shells[i].GetComponent<MeshRenderer>().material = rareMat;
            }
        }
    }
}
