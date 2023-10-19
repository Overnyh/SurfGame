using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

public class AudioScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioClip goodSound;
    [SerializeField] private AudioClip badSound;
    
    private Button _button;
    private AudioSource _audioSource;


    private void Start()
    {
        _button = GetComponent<Button>();
        _audioSource = YandexGame.Instance.gameObject.GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_button.interactable)
        {
            if(goodSound != null)
                _audioSource.PlayOneShot(goodSound);
        }
        else
        {
            _audioSource.PlayOneShot(badSound);
        }
    }
}
