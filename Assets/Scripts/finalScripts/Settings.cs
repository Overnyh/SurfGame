using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Transform characterController = null;
    [SerializeField] Transform characterCamera = null;

    [SerializeField] GameObject buttonHop = null;
    [SerializeField] GameObject buttonF = null;
    [SerializeField] GameObject JS = null;

    public float Sensitivity = 100;
    public bool AoutoHop = true, Mobile = false;

    void Start()
    {
        if (Mobile) 
        {
            JS.SetActive(true);
            buttonHop.SetActive(true);
            buttonF.SetActive(true);

            characterCamera.GetComponent<CameraMovement>().enabled = false;
            characterCamera.GetComponent<MB_MouseLook>().enabled = true;
            characterCamera.GetComponent<MB_MouseLook>().sensitivity = Sensitivity;


            characterController.GetComponent<PlayerMovement>().enabled = false;
            characterController.GetComponent<MB_PlayerMovement>().enabled = true;
            characterController.GetComponent<MB_PlayerMovement>().AutoHop = AoutoHop;
        }
        else
        {
            JS.SetActive(false);
            buttonHop.SetActive(false);
            buttonF.SetActive(false);

            characterCamera.GetComponent<MB_MouseLook>().enabled = false;
            characterCamera.GetComponent<CameraMovement>().enabled = true;
            characterCamera.GetComponent<CameraMovement>().sensitivity = Sensitivity;


            characterController.GetComponent<MB_PlayerMovement>().enabled = false;
            characterController.GetComponent<PlayerMovement>().enabled = true;
            characterController.GetComponent<PlayerMovement>().AutoHop = AoutoHop;
        }
        
        //characterCamera.GetComponent<CameraMovement>().sensitivity = Sensitivity;
        //characterCamera.GetComponent<MB_MouseLook>().sensitivity = Sensitivity;

        //characterController.GetComponent<PlayerMovement>().AutoHop = AoutoHop;
        //characterController.GetComponent<MB_PlayerMovement>().AutoHop = AoutoHop;
    }
}
