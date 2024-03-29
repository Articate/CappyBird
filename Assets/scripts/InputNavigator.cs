﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class InputNavigator : MonoBehaviour
{
    EventSystem system;
    public InputField inputName;
    // void Start()
    // {
    //     system = EventSystem.current;// EventSystemManager.currentSystem;
     
    // }
    // Update is called once per frame
    void Update()
    {
        system = EventSystem.current;
        if (Input.GetKeyDown(KeyCode.Tab))
        { 
           
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {
             
                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null)
                    inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret
             
                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
            if( next == null){
                inputName.ActivateInputField();
            }
            //else Debug.Log("next nagivation element not found");
         
        }
    }
}