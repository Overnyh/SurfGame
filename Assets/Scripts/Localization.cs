using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class Localization : MonoBehaviour
{
   [SerializeField] private Image back;
   private void OnEnable() => YandexGame.GetDataEvent += StartFeed;
   private void OnDisable() => YandexGame.GetDataEvent -= StartFeed;

   private void Awake()
   {
      if (YandexGame.SDKEnabled)
      {
         StartFeed();
      }
   }

   IEnumerator SetLocale(string locale)
   {
      yield return LocalizationSettings.InitializationOperation;
      if (locale == "ru")
      {
         LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
      }
      else
      {
         LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
      }
      back.DOFade(0, 0.5f).OnComplete(() => back.gameObject.SetActive(false));
     
   }
   private void StartFeed()
   {
      StartCoroutine(SetLocale(YandexGame.EnvironmentData.language));
   }
}

