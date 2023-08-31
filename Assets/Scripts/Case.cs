using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Case : MonoBehaviour
{
    [SerializeField] private GameObject ribbon;
    [SerializeField] private List<GameObject> items;
    [SerializeField] private int itemsInCase;
    [SerializeField] private int openTime;
    [SerializeField] private Ease ease;

    private const int ItemSize = 100;

    private Tween _caseAnim;

    public void OpenCase()
    {
        if (_caseAnim is { active: true })
        {
            _caseAnim.Kill();
        }

        ribbon.transform.localPosition = new Vector3(0, ribbon.transform.position.y, 0);

        foreach (Transform child in ribbon.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < itemsInCase; i++)
        {
            Instantiate(items[Random.Range(0, items.Count)], ribbon.transform);
        }
        _caseAnim = ribbon.transform
            .DOLocalMoveX(-ItemSize * (itemsInCase - 4) + Random.Range(-(ItemSize / 2 - 1), ItemSize / 2 - 1), openTime)
            .SetEase(ease);
    }
}