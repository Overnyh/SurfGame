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
        YandexGame.SaveProgress();
    }
    
    void FailedPurchased(string id)
    {
        print("Error: "+id);
    }
}
