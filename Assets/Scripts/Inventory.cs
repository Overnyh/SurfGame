using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private GameObject inventoryPanel;

    private InventoryItem[] _inventoryItems;
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start()
    {
        _inventoryItems = inventoryPanel.GetComponentsInChildren<InventoryItem>();
        InventoryItem.InventoryPanel = inventoryPanel;
        InventoryItem.Inventory = this;
        if (YandexGame.SDKEnabled)
        {
            GetLoad();
        }
    }

    public void UpdateInventory()
    {
        foreach (var inventoryItem in _inventoryItems)
        {
            inventoryItem.SetKnife();
        }
    }
    
    public void GetLoad()
    {
        img.sprite = _inventoryItems.First(item => item.knifeItem.KnifeId == YandexGame.savesData.TackenKnifeId).knifeItem.WinImage;
    }
}
