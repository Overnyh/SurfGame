using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Settings : MonoBehaviour
{
    [SerializeField] Transform characterController = null;
    [SerializeField] Transform characterCamera = null;

    [SerializeField] GameObject buttonHop = null;
    [SerializeField] GameObject buttonF = null;
    [SerializeField] GameObject JS = null;

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider slider;
    [SerializeField] private Toggle toggle;

    public int Sensitivity = 100;
    public bool AoutoHop = true, Mobile = false;

    private void Awake()
    {
        Sensitivity = YandexGame.savesData.Sensitivity;
        AoutoHop = YandexGame.savesData.AutoHope;
        Mobile = YandexGame.EnvironmentData.isMobile;
    }

    void Start()
    {
        if (Mobile) 
        {
            JS.SetActive(true);
            buttonHop.SetActive(true);
            buttonF.SetActive(true);

            characterCamera.GetComponent<PC_MouseLook>().enabled = false;
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
            characterCamera.GetComponent<PC_MouseLook>().enabled = true;
            characterCamera.GetComponent<PC_MouseLook>().sensitivity = Sensitivity;


            characterController.GetComponent<MB_PlayerMovement>().enabled = false;
            characterController.GetComponent<PlayerMovement>().enabled = true;
            characterController.GetComponent<PlayerMovement>().AutoHop = AoutoHop;
        }

        slider.value = Sensitivity;
        toggle.isOn = AoutoHop;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SettingsPanelVisibility(!settingsPanel.activeSelf);
        }
    }

    public void SensitivityUpdate(Slider slider)
    {
        Sensitivity = (int)slider.value;
    }
    
    public void AutoHopUpdate(Toggle toggle)
    {
        AoutoHop = toggle.isOn;
    }

    public void SaveSettings()
    {
        YandexGame.savesData.Sensitivity = Sensitivity;
        YandexGame.savesData.AutoHope = AoutoHop;
        if (Mobile)
        {
            characterCamera.GetComponent<MB_MouseLook>().sensitivity = Sensitivity;
            characterController.GetComponent<MB_PlayerMovement>().AutoHop = AoutoHop;
        }
        else
        {
            characterCamera.GetComponent<PC_MouseLook>().sensitivity = Sensitivity;
            characterController.GetComponent<PlayerMovement>().AutoHop = AoutoHop;
        }
        
    }

    public void SettingsPanelVisibility(bool visible)
    {
        if (!visible)
        {
            settingsPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SaveSettings();

            characterCamera.GetComponent<MB_MouseLook>().enabled = true;
            characterCamera.GetComponent<PC_MouseLook>().enabled = true;
        }
        else
        {
            settingsPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            characterCamera.GetComponent<MB_MouseLook>().enabled = false;
            characterCamera.GetComponent<PC_MouseLook>().enabled = false;
        }
        
    }
}
