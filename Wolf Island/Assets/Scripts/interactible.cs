using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class interactible : MonoBehaviour
{
    private bool _isHighlighted = false;

    public TMP_Text nameDisplay;
    public string displayText;


    private void Awake()
    {
        nameDisplay.text = "";

    }

    public void ShowItemInteractible()
    { 
        if(!_isHighlighted)
        {
            _isHighlighted = true;
            this.GetComponent<Renderer>().material.EnableKeyword("_EMMISION");
            nameDisplay.text = displayText;
        }

    

    }
    public void HideInteractible()
    {
       // nameDisplay
    }
       // display interactible


}
