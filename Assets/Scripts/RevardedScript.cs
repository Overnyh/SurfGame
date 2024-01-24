using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using YG;

public class RevardedScript : MonoBehaviour
{
    [SerializeField] private GameObject onOpen;
    [SerializeField] private Case caseScript;

    private bool isGood;
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        YandexGame.CloseVideoEvent += StartCaseX3;
        isGood = false;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
        YandexGame.CloseVideoEvent -= StartCaseX3;
    }

    void Rewarded(int id)
    {
        if (id == 1)
        {
            isGood = true;
        }
    }

    void StartCaseX3()
    {
        if (isGood)
        {
            StartCoroutine(Run());
        }
    }

    IEnumerator Run()
    {
        yield return new WaitForSeconds(0.2f);
        isGood = false;
        onOpen.SetActive(true);
        caseScript.CaseOpenX3();
    }
    
}
