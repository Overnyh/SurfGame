using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;


public class Case : MonoBehaviour
{
    [SerializeField] private GameObject ribbon;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject openCasePanel;
    [SerializeField] private Image rareImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private List<Sprite> rareImageList;
    [SerializeField] private List<GameObject> items;
    [SerializeField] private int itemsInCase;
    [SerializeField] private int openTime;
    [SerializeField] private Ease ease;
    [SerializeField] private int trashChance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip onOpen;
    [SerializeField] private AudioClip onWin;

    private const int ItemSize = 400;
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
        winPanel.SetActive(false);
        openCasePanel.SetActive(true);
    }

    public void CaseOpen()
    {
        audioSource.PlayOneShot(onOpen);
        
        System.Random rnd = new System.Random();
        int winNumber = GetWinItem(rnd);
        GameObject winItem = items[winNumber];


        for (int i = 0; i < itemsInCase; i++)
        {
            Instantiate(i == itemsInCase - WinItemPosition ? winItem : items[GetWinItem(rnd)], ribbon.transform);
            // Instantiate(i == itemsInCase - WinItemPosition ? winItem : items[rnd.Next(items.Count)], ribbon.transform);
        }

        ribbon.transform
            .DOLocalMoveX(-ItemSize * (itemsInCase - WinItemPosition) + ItemBias(rnd), openTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                KnifeItem knifeItem = items[winNumber].GetComponent<KnifeItem>();
                GameObject imgObject = new GameObject("winItem");
                RectTransform trans = imgObject.AddComponent<RectTransform>();
                trans.sizeDelta= new Vector2(400, 400);
                Image image = imgObject.AddComponent<Image>();
                image.sprite = knifeItem.WinImage;
                nameText.text = knifeItem.KnifeName;
                
                rareImage.sprite = rareImageList[knifeItem.Rare ? 1 : 0];
                audioSource.PlayOneShot(onWin);
                winPanel.SetActive(true);
                _winItem = Instantiate(imgObject, winPanel.transform);
                Destroy(imgObject);
                _winItem.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                _winItem.transform.DOScale(new Vector3(2, 2, 2), 0.5f).SetEase(Ease.OutBounce);

                YandexGame.savesData.OpenKnifes[knifeItem.KnifeId] = true;
                YandexGame.SaveProgress();
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