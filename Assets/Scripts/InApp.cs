using System;
using System.Collections.Generic;
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
        TrigerSend(id);
        YandexGame.SaveProgress();
        ListItemUpdate();
    }
    
    private void TrigerSend(string name)
    {
        var eventParams = new Dictionary<string, string>
        {
            { "knifeBuy", name }
        };

        YandexMetrica.Send("knifeBuy", eventParams);
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
