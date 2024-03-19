using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    //selection
    private string _selectTag;
    public Material highlightMaterial;
    private bool _isHighlighted = false;

    private Transform _selection;

    public TMP_Text nameDisplay;

    public float distancefromitem = 3f;


    //door

    public Animator dooranimator;
    public GameObject doorText;
    public bool hasKey = true;
    private bool _isOpen = false;

    private void Update()
    {
        if (_selection != null)
        {
            nameDisplay.text = "";
            _isHighlighted = false;
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.DisableKeyword("_EMISSION");
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distancefromitem, Color.red);

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distancefromitem))
        {
            //Debug.Log("test");

            var selection = hit.transform;

            if(selection.CompareTag("Unikeselectionboat") || selection.CompareTag("door"))
            {
                if (selection != _isHighlighted)
                {
                    nameDisplay.text = selection.gameObject.name;
                    _isHighlighted = true;
                    selection.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                }
                _selection = selection;
            }

        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            DoorInteraction();
        }



    }

    void DoorInteraction()
    {
        RaycastHit hitInfo;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray rayOrgin = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(rayOrgin, out hitInfo, distancefromitem))
        {
            var selection = hitInfo.transform;
            if (!hasKey)
            {
                doorText.SetActive(true);
                Invoke("DisableText", 2f);

            }
            else 
            {
                if (selection.gameObject.tag == "door")
                {
                    if (!_isOpen)
                    {
                        dooranimator.SetTrigger("door-open");
                        dooranimator.ResetTrigger("door-close");
                        _isOpen = true;
                    }
                    else
                    {
                        dooranimator.SetTrigger("door-close");
                        dooranimator.ResetTrigger("door-open");
                        _isOpen = false;
                    }
                }
            
            }
        }
    }
    void DisableText()
    {
        doorText.SetActive(false);
    }

   private void OnTriggerEnter(Collider other)
   {
        if (other.gameObject.CompareTag("key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("cavetp"))
        {
            SceneManager.LoadScene("cave2");
        }
        if (other.gameObject.CompareTag("maintp"))
        {
            SceneManager.LoadScene("main");
        }
    }
}
