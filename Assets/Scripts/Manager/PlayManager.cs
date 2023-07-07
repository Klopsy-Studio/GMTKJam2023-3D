using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public static PlayManager instance;

    public List<StageState> desiredStageStates;
    public StageState currentStageStates;


    int actionIndex;

    [SerializeField] Image timerImage;
    [SerializeField] float timer;
    float maxTimer;

    public int failures;

    bool failed;
    bool completed;
    private void Awake()
    {
        instance = this;
        currentStageStates = new StageState();

        maxTimer = timer;

    }

    public void Update()
    {
        if (!failed && !completed)
        {
            timer -= Time.deltaTime;
            timerImage.fillAmount -= 1f / maxTimer * Time.deltaTime;

            if (timer <= 0)
            {

                if (CheckDesiredState())
                {
                    Debug.Log("Success");
                }
                else
                {
                    AddFailure();
                }

                if (actionIndex >= desiredStageStates.Count)
                {
                    completed = true;
                }

                ResetTimer();
            }

        }

    }

    public void ChangeBackground(int index)
    {
        currentStageStates.background = index;
    }
    public bool CheckDesiredState()
    {
        StageState desired = desiredStageStates[actionIndex];
        StageState current = currentStageStates;

        if (current.bar1Active != desired.bar1Active)
            return false;
        if (current.bar2Active != desired.bar2Active)
            return false;
        if (current.bar3Active != desired.bar3Active)
            return false;
        if (current.music != desired.music)
            return false;
        if (current.soundEffect != desired.soundEffect)
            return false;
        if (current.leftLightColor != desired.leftLightColor)
            return false;
        if (current.leftLightIntensity != desired.leftLightIntensity)
            return false;
        if (current.rightLightColor != desired.rightLightColor)
            return false;
        if (current.rightLightIntensity != desired.rightLightIntensity)
            return false;
        if (current.centerLightColor != desired.centerLightColor)
            return false;
        if (current.centerLightIntensity != desired.centerLightIntensity)
            return false;
        if (current.background != desired.background)
            return false;

        return true;

    }
    public void ChangeSoundEffectTone(SoundTone tone)
    {
        currentStageStates.soundEffect = tone;
    }
    
    public void ChangeMusicTone(SoundTone tone)
    {
        currentStageStates.music = tone;
    }

    public void ToggleBar(int index, bool toggle)
    {
        switch (index)
        {
            case 1:
                currentStageStates.bar1Active = toggle;
                break;
            case 2:
                currentStageStates.bar2Active = toggle;
                break;
            case 3:
                currentStageStates.bar3Active = toggle;
                break;
            default:
                break;
        }
    }

    public void ChangeLight(int index, LightIntensity intensity, LightColor color)
    {
        switch (index)
        {
            case 1:
                currentStageStates.leftLightColor = color;
                currentStageStates.leftLightIntensity = intensity;

                break;
            case 2:
                currentStageStates.centerLightColor = color;
                currentStageStates.centerLightIntensity = intensity;
                break;
            case 3:
                currentStageStates.rightLightColor = color;
                currentStageStates.rightLightIntensity = intensity; 
                break;
            default:
                break;
        }
    }

    public void AddFailure()
    {
        failures++;
        Debug.Log("Failure");

        if (failures >= 3)
        {
            failed = true;
            Debug.Log("Game Over");

        }
    }
    public void ResetTimer()
    {
        timer = maxTimer;
        timerImage.fillAmount = 1;
    }

}
