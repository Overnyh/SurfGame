using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private int itemId;
    private Button _button;
    private Image _sprite;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += UpdateVisability;
        InApp.OnPurchaseComplete += UpdateVisability;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= UpdateVisability;
        InApp.OnPurchaseComplete -= UpdateVisability;
    } 


    private void Start()
    {
        _button = GetComponent<Button>();
        _sprite = GetComponent<Image>();
        if (YandexGame.SDKEnabled)
        {
            UpdateVisability();
        }
    }

    private void UpdateVisability()
    {
        _button.interactable = !YandexGame.savesData.OpenKnifes[itemId];
        _sprite.color = new Color(255, 255, 255, !YandexGame.savesData.OpenKnifes[itemId]? 1: 0.5f);
      
    }
}
