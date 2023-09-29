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
    [SerializeField] private GameObject ribbonX3;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject openCasePanel;
    [SerializeField] private GameObject onOpenPanel;
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
    [SerializeField] private GameObject GoldText;
    [SerializeField] private GameObject BaseText;
    

    private const int ItemSize = 400;
    private const int ItemSizeX3 = 250;
    private const int WinItemPosition = 4;

    private GameObject _winItem;
    private List<KnifeItem> _winItems = new List<KnifeItem>();

    public void OpenCasePanel()
    {
        ribbon.transform.localPosition = new Vector3(0, ribbon.transform.position.y, 0);
        ribbonX3.transform.localPosition = new Vector3(0, ribbon.transform.position.y, 0);
        foreach (Transform child in ribbon.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in ribbonX3.transform)
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
                ShowWinItem(items[winNumber].GetComponent<KnifeItem>());
            });
    }
    public void CaseOpenX3()
    {
        audioSource.PlayOneShot(onOpen);
        
        System.Random rnd = new System.Random();
        var winNumber = new[] { GetWinItem(rnd), GetWinItem(rnd), GetWinItem(rnd) };
        var winItem = new[] {items[winNumber[0]], items[ winNumber[1]], items[ winNumber[2]]};
        
        for (int i = 0; i < itemsInCase*3; i++)
        {
            var obj = Instantiate(i/3 == itemsInCase - WinItemPosition ? winItem[i%3] : items[GetWinItem(rnd)], ribbonX3.transform);
            obj.GetComponent<BoxCollider>().size = new Vector3(ItemSizeX3, ItemSizeX3, 1);
        }

        ribbonX3.transform
            .DOLocalMoveX(-ItemSizeX3 * (itemsInCase - WinItemPosition) + ItemBias(rnd, true), openTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                ShowWinItem(items[winNumber[0]].GetComponent<KnifeItem>());
                _winItems.Add(items[winNumber[1]].GetComponent<KnifeItem>());
                _winItems.Add(items[winNumber[2]].GetComponent<KnifeItem>());
            });
    }

    private void ShowWinItem(KnifeItem knifeItem)
    {
        GameObject imgObject = new GameObject("winItem");
        RectTransform trans = imgObject.AddComponent<RectTransform>();
        trans.sizeDelta= new Vector2(400, 400);
        Image image = imgObject.AddComponent<Image>();
        image.sprite = knifeItem.WinImage;
        nameText.text = knifeItem.KnifeName;

  
        GoldText.SetActive(knifeItem.Rare);
        BaseText.SetActive(!knifeItem.Rare);
        rareImage.sprite = rareImageList[knifeItem.Rare ? 1 : 0];
        audioSource.PlayOneShot(onWin);
        winPanel.SetActive(true);
        _winItem = Instantiate(imgObject, winPanel.transform);
        Destroy(imgObject);
        _winItem.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        _winItem.transform.DOScale(new Vector3(2, 2, 2), 0.5f).SetEase(Ease.OutBounce);
                
        YandexGame.savesData.OpenKnifes[knifeItem.KnifeId] = true;
        YandexGame.SaveProgress();
    }

    public void TryClose()
    {
        if (_winItems.Count > 0)
        {
            var item = _winItems[0];
            Destroy(_winItem);
            ShowWinItem(item);
            _winItems.Remove(item);
        }
        else
        {
            onOpenPanel.SetActive(false);
            openCasePanel.SetActive(false);
        }
    }

    private int ItemBias(System.Random rnd, bool isSmall = false)
    {
        return isSmall ? rnd.Next(-(ItemSizeX3 / 2 - 1), ItemSizeX3 / 2 - 1) : rnd.Next(-(ItemSize / 2 - 1), ItemSize / 2 - 1);
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