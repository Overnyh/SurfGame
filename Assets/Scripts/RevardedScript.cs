using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class RevardedScript : MonoBehaviour
{
    [SerializeField] private GameObject onOpen;
    [SerializeField] private Case caseScript;
    
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;
    
    void Rewarded(int id)
    {
        if (id == 1)
        {
            onOpen.SetActive(true);
            caseScript.CaseOpenX3();
        }
    }
    
}
