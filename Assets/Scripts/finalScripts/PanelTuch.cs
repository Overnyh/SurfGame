using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class PanelTuch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject mb_mouselook;
    
    bool pressed = false;
    //private int fingerId;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == gameObject)
        {
            pressed = true;
            //fingerId = eventData.pointerId;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    void Update()
    {
        mb_mouselook.GetComponent<MB_MouseLook>().pressed = pressed;
    }
}
