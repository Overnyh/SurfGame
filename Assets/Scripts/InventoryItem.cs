using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

public class InventoryItem : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] public KnifeItem knifeItem;
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI colour;

    public static GameObject InventoryPanel;
    public static Inventory Inventory;
    public void SetKnife()
    {
        img.sprite = knifeItem.InventoryImage;
        var tempColor = img.color;
        tempColor.a = YandexGame.savesData.OpenKnifes[knifeItem.KnifeId] ? 1 : 0.5f;
        img.color = tempColor;

        name.text = knifeItem.KnifeName.Split(" | ")[0];
        name.color = tempColor;
        colour.text = knifeItem.KnifeName.Split(" | ")[1];
        colour.color = tempColor;
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        if (YandexGame.savesData.OpenKnifes[knifeItem.KnifeId])
        {
            print("Take");
            YandexGame.savesData.TackenKnifeId = knifeItem.KnifeId;
            YandexGame.SaveProgress();
            Inventory.GetLoad();
            InventoryPanel.SetActive(false);
        }
        else
        {
            print("Nope");
        }
    }
}