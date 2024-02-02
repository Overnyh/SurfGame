using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using YG;

public class Settings : MonoBehaviour
{
    [SerializeField] Transform characterController = null;
    [SerializeField] Transform characterCamera = null;

    [SerializeField] GameObject buttonHop = null;
    [SerializeField] GameObject buttonF = null;
    [SerializeField] GameObject JS = null;
    [SerializeField] GameObject settings = null;
    [SerializeField] GameObject help = null;
    [SerializeField] GameObject TouchPanel = null;

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private UnityEngine.UI.Toggle toggle;


    public int Sensitivity = 100;
    public bool AoutoHop = true, Mobile = false;
    bool show = true;

    private void Awake()
    {
        #if !UNITY_EDITOR
        Sensitivity = YandexGame.savesData.Sensitivity;
        AoutoHop = YandexGame.savesData.AutoHope;
        Mobile = YandexGame.EnvironmentData.isMobile;
        #endif
    }

    void Start()
    {

        //QualitySettings.vSyncCount = 0;  // Отключаем вертикальную синхронизацию
        //print(QualitySettings.vSyncCount);
        Application.targetFrameRate = 60;  // Устанавливаем целевой FPS
        Time.fixedDeltaTime = 1f / 60;  // Устанавливаем фиксированный интервал времени

        if (Mobile) 
        {
            JS.SetActive(true);
            settings.SetActive(true);
            buttonHop.SetActive(true);
            buttonF.SetActive(true);
            TouchPanel.SetActive(true);

            settingsPanel.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            slider.transform.localScale = new Vector3(1, 1.6f, 1);
            slider.transform.GetChild(0).transform.localScale = new Vector3(1.35f, 1, 1);
            slider.transform.GetChild(2).GetChild(0).transform.localScale = new Vector3(1.65f, 1, 1);

            toggle.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            toggle.transform.GetChild(1).transform.localScale = new Vector3(0.9f, 1, 1);

            settingsPanel.transform.GetChild(4).transform.localScale = new Vector3(1.85f, 1.85f, 1);

            characterCamera.GetComponent<PC_MouseLook>().enabled = false;
            TouchPanel.GetComponent<TouchCameraMove>().sensitivity = Sensitivity;
            //characterCamera.GetComponent<MB_MouseLook>().enabled = true;
            //characterCamera.GetComponent<MB_MouseLook>().sensitivity = Sensitivity;


            characterController.GetComponent<PlayerMovement>().enabled = false;
            characterController.GetComponent<MB_PlayerMovement>().enabled = true;
            characterController.GetComponent<MB_PlayerMovement>().AutoHop = AoutoHop;
        }
        else
        {
            JS.SetActive(false);
            settings.SetActive(false);
            buttonHop.SetActive(false);
            buttonF.SetActive(false);

            help.SetActive(true);
            TouchPanel.SetActive(false);

            //characterCamera.GetComponent<MB_MouseLook>().enabled = false;
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
        if (Input.GetKeyDown(KeyCode.Tab) && !Mobile)
        {
            show = !show;
            help.SetActive(show);
        }
    }

    public void SensitivityUpdate(UnityEngine.UI.Slider slider)
    {
        Sensitivity = (int)slider.value;
    }
    
    public void AutoHopUpdate(UnityEngine.UI.Toggle toggle)
    {
        AoutoHop = toggle.isOn;
    }

    public void SaveSettings()
    {
        YandexGame.savesData.Sensitivity = Sensitivity;
        YandexGame.savesData.AutoHope = AoutoHop;
        if (Mobile)
        {
            //characterCamera.GetComponent<MB_MouseLook>().sensitivity = Sensitivity;
            TouchPanel.GetComponent<TouchCameraMove>().sensitivity = Sensitivity;
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
        if (Mobile)
        {
            if (!visible)
            {
                settingsPanel.SetActive(false);
                SaveSettings();
            }
            else
            {
                settingsPanel.SetActive(true);
            }
        }
        else
        {
            if (!visible)
            {
                settingsPanel.SetActive(false);
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                UnityEngine.Cursor.visible = false;
                SaveSettings();
                characterCamera.GetComponent<PC_MouseLook>().enabled = true;
            }
            else
            {
                settingsPanel.SetActive(true);
                UnityEngine.Cursor.lockState = CursorLockMode.Confined;
                UnityEngine.Cursor.visible = true;
                characterCamera.GetComponent<PC_MouseLook>().enabled = false;
            }
        }
    }
}
