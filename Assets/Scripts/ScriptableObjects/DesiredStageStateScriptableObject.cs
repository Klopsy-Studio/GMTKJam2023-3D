using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesiredStageStateScriptableObject : ScriptableObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class StageState
{
    [Header("Sound State")]
    public SoundTone soundEffect;
    public SoundTone music;
    [Space]
    [Header("Left Light State")]
    public LightIntensity leftLightIntensity;
    public LightColor leftLightColor;
    [Space]
    [Header("Center Light State")]
    public LightIntensity centerLightIntensity;
    public LightColor centerLightColor;
    [Space]
    [Header("Right Light State")]
    public LightIntensity rightLightIntensity;
    public LightColor rightLightColor;
    [Space]
    [Header("Props State")]
    public bool bar1Active;
    public bool bar2Active;
    public bool bar3Active;
    [Header("Background State")]
    public int background = 1;
}

public enum SoundTone
{
    none, surprise, dramatic, sad, romantic
};

public enum SoundType
{
    music, sound
};
