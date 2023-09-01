using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class Case : MonoBehaviour
{
    [SerializeField] private GameObject ribbon;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject openCasePanel;
    [SerializeField] private GameObject openButton;
    [SerializeField] private List<GameObject> items;
    [SerializeField] private int itemsInCase;
    [SerializeField] private int openTime;
    [SerializeField] private Ease ease;
    [SerializeField] private int trashChance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip onOpen;
    [SerializeField] private AudioClip onWin;

    private const int ItemSize = 200;
    private const int WinItemPosition = 4;

    private GameObject _winItem;

    public void OpenCasePanel()
    {
        ribbon.transform.localPosition = new Vector3(0, ribbon.transform.position.y, 0);
        foreach (Transform child in ribbon.transform)
        {
            Destroy(child.gameObject);
        }
        if (_winItem)
        {
            Destroy(_winItem);
        }
        openButton.SetActive(true);
        winPanel.SetActive(false);
        openCasePanel.SetActive(true);
    }

    public void CaseOpen()
    {
        openButton.SetActive(false);
        audioSource.PlayOneShot(onOpen);
        
        System.Random rnd = new System.Random();

        GameObject winItem = items[GetWinItem(rnd)];

        for (int i = 0; i < itemsInCase; i++)
        {
            Instantiate(i == itemsInCase - WinItemPosition ? winItem : items[rnd.Next(items.Count)], ribbon.transform);
        }

        ribbon.transform
            .DOLocalMoveX(-ItemSize * (itemsInCase - WinItemPosition) + ItemBias(rnd), openTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                audioSource.PlayOneShot(onWin);
                winPanel.SetActive(true);
                _winItem = Instantiate(winItem, winPanel.transform);
                _winItem.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                _winItem.transform.DOScale(new Vector3(2, 2, 2), 0.5f).SetEase(Ease.OutBounce);
            });
    }

    private int ItemBias(System.Random rnd)
    {
        return rnd.Next(-(ItemSize / 2 - 1), ItemSize / 2 - 1);
    }

    private int GetWinItem(System.Random rnd, bool iswin = false)
    {
        var chance = rnd.Next(100) + 1;
        if (iswin)
        {
            print(chance + "  " + trashChance);
            print(chance < trashChance);
        }

        return chance < trashChance ? 0 : rnd.Next(1, items.Count);
    }
}