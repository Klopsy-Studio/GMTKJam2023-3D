using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLight : MonoBehaviour
{
    [SerializeField] int lightIndex;
    [SerializeField] LightIntensity currentIntensity = 0;
    public int intensityLimit = 2;
    [SerializeField] LightColor currentColor = 0;
    public int colorLimit = 3;

    [SerializeField] Light currentLight;


    [Header("Objects")]
    [SerializeField] GameObject intensityOff;
    [SerializeField] GameObject intensityMedium;
    [SerializeField] GameObject intensityHigh;
    [Space]
    [SerializeField] GameObject whiteMode;
    [SerializeField] GameObject blueMode;
    [SerializeField] GameObject purpleMode;
    [SerializeField] GameObject redMode;

    public void ChangeLightIntensity()
    {
        currentIntensity++;

        if((int)currentIntensity > intensityLimit)
        {
            currentIntensity = 0;
        }

        switch (currentIntensity)
        {
            case LightIntensity.off:
                currentLight.intensity = 0;
                ShowCorrectIntensity(intensityOff);
                break;
            case LightIntensity.medium:
                ShowCorrectIntensity(intensityMedium);
                currentLight.intensity = 10;
                break;
            case LightIntensity.high:
                ShowCorrectIntensity(intensityHigh);
                currentLight.intensity = 30;
                break;
            default:
                break;
        }

        RecordActionLight();
    }

    public void ShowCorrectIntensity(GameObject obj)
    {
        intensityOff.SetActive(false);
        intensityMedium.SetActive(false);
        intensityHigh.SetActive(false);

        obj.SetActive(true);
        obj.transform.SetAsFirstSibling();
    }

    public void ShowCorrectColor(GameObject obj)
    {
        whiteMode.SetActive(false);
        redMode.SetActive(false);
        blueMode.SetActive(false);
        purpleMode.SetActive(false);

        obj.SetActive(true);
    }
    public void ChangeLightColor()
    {
        currentColor++;

        if ((int)currentColor > colorLimit)
        {
            currentColor = 0;
        }

        switch (currentColor)
        {
            case LightColor.white:
                currentLight.color = Color.white;
                ShowCorrectColor(whiteMode);
                break;
            case LightColor.blue:
                currentLight.color = Color.blue;
                ShowCorrectColor(blueMode);
                break;
            case LightColor.purple:
                currentLight.color = Color.magenta;
                ShowCorrectColor(purpleMode);
                break;
            case LightColor.red:
                currentLight.color = Color.red;
                ShowCorrectColor(redMode);
                break;
            default:
                break;
        }

        RecordActionLight();
    }

    public void SetInitialLightSettings(LightColor color, LightIntensity intensity)
    {
        switch (color)
        {
            case LightColor.white:
                currentLight.color = Color.white;
                ShowCorrectColor(whiteMode);
                break;
            case LightColor.blue:
                currentLight.color = Color.blue;
                ShowCorrectColor(blueMode);
                break;
            case LightColor.purple:
                currentLight.color = Color.magenta;
                ShowCorrectColor(purpleMode);
                break;
            case LightColor.red:
                currentLight.color = Color.red;
                ShowCorrectColor(redMode);
                break;
            default:
                break;
        }

        currentColor = color;

        switch (intensity)
        {
            case LightIntensity.off:
                currentLight.intensity = 0;
                ShowCorrectIntensity(intensityOff);
                break;
            case LightIntensity.medium:
                ShowCorrectIntensity(intensityMedium);
                currentLight.intensity = 10;
                break;
            case LightIntensity.high:
                ShowCorrectIntensity(intensityHigh);
                currentLight.intensity = 30;
                break;
            default:
                break;
        }

        currentIntensity = intensity;
    }
    public void RecordActionLight()
    {
        PlayManager.instance.ChangeLight(lightIndex, currentIntensity, currentColor);
    }
}

public enum LightIntensity
{
    off, medium, high
};

public enum LightColor
{
    white, blue, purple, red
};


