using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using YG;

public class KnifeItem : MonoBehaviour
{
    [SerializeField] public int KnifeId;

    [SerializeField] private string KnifeNameEn;
    [SerializeField] private string KnifeNameRu; 
    public string KnifeName
    {
        get { return YandexGame.EnvironmentData.language == "ru" ? KnifeNameRu : KnifeNameEn; }
    }

    [SerializeField] public Sprite InventoryImage;
    [SerializeField] public Sprite WinImage;
    [SerializeField] public bool Rare;
}