using System;
using UnityEngine;
using YG;

public class InApp : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.PurchaseSuccessEvent += SuccessPurchased;
        YandexGame.PurchaseFailedEvent += FailedPurchased;
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
    }

    void FailedPurchased(string id)
    {
        print("Error: "+id);
    }
}
