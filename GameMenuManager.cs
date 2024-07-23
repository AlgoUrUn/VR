using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GameMenuManager : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty showButton;


    void Update()
    {
        if(showButton.action.WasPressedThisFrame()) {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
