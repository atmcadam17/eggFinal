using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customizeColor : MonoBehaviour
{
    [SerializeField] private GameObject _featureToChange; // what part of the body to change
    [SerializeField] private GameObject _leftButton; // not actually a button
    [SerializeField] private GameObject _rightButton; // also not actually a button
    [SerializeField] private List<Material> _matList; // list of materials to cycle through
    
    private int _currentMatIndex;
    private bool hoverLeft = false;
    private bool hoverRight = false;

    private int mask;
    
    public enum dir
    {
        left,
        right
    }
    
    void Start()
    {
        _currentMatIndex = 0;
        UpdateColor();
        mask = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.current != null && Camera.current.name == "laundryCam")
        {
            Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // checks if ur hovering over or pressing one of the buttons
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~mask))
            {
                if (hit.collider == _leftButton.GetComponent<Collider>())
                {
                    hoverLeft = true;
                } else if (hit.collider == _rightButton.GetComponent<Collider>())
                {
                    hoverRight = true;
                }
                else
                {
                    hoverLeft = false;
                    hoverRight = false;
                }
            }
        }

        // cycle through _matList if you click while ur mouse is over one of the buttons
        if (hoverLeft)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CycleColor(dir.left);
                HighlightButton(_leftButton);
            }
        } else if (hoverRight)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CycleColor(dir.right);
                HighlightButton(_rightButton);
            }
        }
        
        // resets colors when mouse goes up, no matter where mouse is
        if (Input.GetMouseButtonUp(0))
        {
            UnhighlightButton(_rightButton);
            UnhighlightButton(_leftButton);
        }
    }

    // changes button color when pressed
    public void HighlightButton(GameObject button)
    {
        button.GetComponent<SpriteRenderer>().color = Color.grey;
    }
    
    // changes color back
    public void UnhighlightButton(GameObject button)
    {
        button.GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    // cycles current color -1 or +1
    public void CycleColor(dir direction)
    {
        if (direction == dir.left && _currentMatIndex > 0) // if left cycle -1
        {
            _currentMatIndex--;
        } else if (direction == dir.right && _currentMatIndex < _matList.Count - 1) // if right cycle +1
        {
            _currentMatIndex++;
        } else if (direction == dir.right && _currentMatIndex == _matList.Count - 1) // if mat index is maxed, loop to start
        {
            _currentMatIndex = 0;
        } else if (direction == dir.left && _currentMatIndex == 0) // same for if it's minimum
        {
            _currentMatIndex = _matList.Count - 1;
        }
        
        UpdateColor();
    }

    // updates color using _matList and current index
    public void UpdateColor()
    {
        _featureToChange.GetComponent<MeshRenderer>().material = _matList[_currentMatIndex];
    }
}
