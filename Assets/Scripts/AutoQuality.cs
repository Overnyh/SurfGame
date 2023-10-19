using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DynamicResolutionController : MonoBehaviour
{
    public float minResolutionScale = 0.65f;
    public float maxResolutionScale = 1.0f;
    
    private float totalTime = 0f;
    private int frameCount = 0;
    private float averageFPS = 0f;
    private float updateInterval = 1.0f;
    private UniversalRenderPipelineAsset urpAsset;
    
    private void Start()
    {
        urpAsset = GraphicsSettings.renderPipelineAsset as UniversalRenderPipelineAsset;
    }

    private void Update()
    {
        totalTime += Time.deltaTime;
        frameCount++;

        if (totalTime > updateInterval)
        {
            averageFPS = frameCount / totalTime;
            ChangeRanderScale();
            totalTime = 0f;
            frameCount = 0;
        }
    }

    private void ChangeRanderScale()
    {
        if (averageFPS > 60.0f)
        {
            urpAsset.renderScale = Mathf.Clamp(urpAsset.renderScale + 0.1f, minResolutionScale, maxResolutionScale);
        }
        else if (averageFPS < 30.0f)
        {
            urpAsset.renderScale = Mathf.Clamp(urpAsset.renderScale - 0.1f, minResolutionScale, maxResolutionScale);
        }
    }

}