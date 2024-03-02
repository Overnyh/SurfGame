using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;
using Random = UnityEngine.Random;


public class FreeKnifeTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject wait;
    [SerializeField] private GameObject done;
    public void Start()
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
        if(!YandexGame.savesData.freeKnife && noKnife)
            StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        wait.SetActive(true);
        while (YandexGame.savesData.freeKnifeTime > 0)
        {
            TimeSpan time = TimeSpan.FromSeconds(YandexGame.savesData.freeKnifeTime);
            text.text = time.ToString(@"mm\:ss");
            yield return new WaitForSeconds(1);
            YandexGame.savesData.freeKnifeTime -= 1;
            YandexGame.SaveProgress();
        }

        List<int> knifs = new List<int>();
        for (int i = 0; i < YandexGame.savesData.KnifesCount; i++)
        {
            if (!YandexGame.savesData.OpenKnifes[i])
            {
                knifs.Add(i);
            }
        }
        int randomElement = knifs[Random.Range(0, knifs.Count)];
        wait.SetActive(false);
        done.SetActive(true);
        YandexGame.savesData.freeKnife = true;
        YandexGame.savesData.OpenKnifes[randomElement] = true;
        YandexGame.SaveProgress();
    }
}
