using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using YG;

public class KnifesManager : MonoBehaviour
{
    public int knifeIndex = 0;

    [SerializeField] GameObject[] array;
    
    Animator knife;

    void Start()
    {
        knifeIndex =  YandexGame.savesData.TackenKnifeId;
        array[knifeIndex].SetActive(true);
        knife = array[knifeIndex].GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.F)) DoF();
    }

    public void DoF()
    {
        if (knife.layerCount == 1)
        {
            knife.Play("KnifeAnim", 0);
        }
        else if (knife.layerCount == 2)
        {
            knife.Play("KnifeAnim", 0);
            knife.Play("KnifeAnim", 1);
        }
    }
}
