using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MenuScript: MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && Input.GetKeyDown(KeyCode.Delete))
        {
            YandexGame.savesData.OpenKnifes = new bool[20];
            YandexGame.savesData.OpenKnifes[0] = true;
            YandexGame.SaveProgress();
        }
    }

    public void LoadLevel(int lvlId)
    {
        SceneManager.LoadScene(lvlId);
    }
}
