using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private bool canClick = false;
    public InputActionAsset NewControls;
    InputActionMap ActionMap;
    [SerializeField] private InputAction click;
    public TMP_Text text;
    private string vText = "It Bloody Worked";
    private string fText = "Find the button";
    
    public void Awake()
    {

        ActionMap = NewControls.FindActionMap("NewControls");
        click = NewControls.FindAction("Click");
       
        click.performed += _ => {
            
             if (canClick == true)
                 {
                    text.SetText(vText);
                    GameManager.Instance.buttClick=true;
                }
        else
        text.SetText(fText);

            };
    }

    private void OnEnable()
    {
        NewControls.Enable();
        
    }
    private void OnDisable()
    {
        NewControls.Disable();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "button")
            canClick = true;
    }
     private void OnTriggerExit (Collider other)
    {
            canClick = false;
    }
  
}
