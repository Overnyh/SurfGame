using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using YG;

public class AlertScript : MonoBehaviour
{
    [SerializeField] private Ease ease;
    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            ShowAlert();
        }
        else
        {
            YandexGame.GetDataEvent += ShowAlert;
        }
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= ShowAlert;
    }

    public void ShowAlert()
    {
        bool noKnife = false;
        for (int i = 0; i < YandexGame.savesData.KnifesCount; i++)
        {
            if (!YandexGame.savesData.OpenKnifes[i])
            {
                noKnife = true;
                break;
            }
        }
        print(YandexGame.savesData.freeKnife);
        if (noKnife && !YandexGame.savesData.freeKnife)
        {
            transform.DOLocalMoveY(-200, 1).SetEase(ease).SetRelative();
        }
    }
}
