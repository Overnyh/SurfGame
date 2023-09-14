using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class RenderQuality : MonoBehaviour
{
    //[SerializeField] private GameObject gm;
    void Start()
    {
        //var urpAsset = (UniversalRenderPipelineAsset)GraphicsSettings.renderPipelineAsset;
        //urpAsset.renderScale = 1f;
    }

    public void Quality(float value)
    {
        //gm.GetComponent<Slider>().value = 0;
        var urpAsset = (UniversalRenderPipelineAsset)GraphicsSettings.renderPipelineAsset;
        urpAsset.renderScale = 1f-value;
    }
}
