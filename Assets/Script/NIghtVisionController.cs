using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class NIghtVisionController : MonoBehaviour
{
    [SerializeField] private Color defaultLightColour;
    [SerializeField] private Color boostedLightColour;

    private bool isNightVisionEnabled;
    private PostProcessVolume volume;
    private void Start()
    {
        RenderSettings.ambientLight = defaultLightColour;
        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.weight = 0;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ToggleNightVision();
        }
    }

    private void ToggleNightVision()
    {
        isNightVisionEnabled = !isNightVisionEnabled;
        if(isNightVisionEnabled)
        {
            RenderSettings.ambientLight = boostedLightColour;
            volume.weight = 1;
        }
        else
        {
            RenderSettings.ambientLight = defaultLightColour;
            volume.weight = 0;
        }
    }
}
