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
                break;
            case LightIntensity.medium:
                currentLight.intensity = 10;
                break;
            case LightIntensity.high:
                currentLight.intensity = 30;
                break;
            default:
                break;
        }

        RecordActionLight();
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
                break;
            case LightColor.blue:
                currentLight.color = Color.blue;
                break;
            case LightColor.purple:
                currentLight.color = Color.magenta;
                break;
            case LightColor.red:
                currentLight.color = Color.red;
                break;
            default:
                break;
        }

        RecordActionLight();
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


