using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class InApp : MonoBehaviour
{
    public delegate void PurchaseEventHandler();
    public static event PurchaseEventHandler OnPurchaseComplete;

    private void OnEnable()
    {
        YandexGame.PurchaseSuccessEvent += SuccessPurchased;
        YandexGame.PurchaseFailedEvent += FailedPurchased;
        YandexGame.GetDataEvent += YandexGame.ConsumePurchases;
        if (YandexGame.SDKEnabled)
        {
            YandexGame.ConsumePurchases();
        }
    }

    private void OnDisable()
    {
        YandexGame.PurchaseSuccessEvent -= SuccessPurchased;
        YandexGame.PurchaseFailedEvent -= FailedPurchased;
    }
    
    void SuccessPurchased(string id)
    {
        print("Good: "+id);
        YandexGame.savesData.OpenKnifes[Convert.ToInt32(id)] = true;
        YandexGame.SaveProgress();
        ListItemUpdate();
    }

    void FailedPurchased(string id)
    {
        print("Error: "+id);
    }

    private void ListItemUpdate()
    {
        OnPurchaseComplete?.Invoke();        
    }
}
