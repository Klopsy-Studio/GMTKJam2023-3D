using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayManager : MonoBehaviour
{
    public static PlayManager instance;

    public StageState beginningStageState;
    public List<StageState> desiredStageStates;
    public StageState currentStageStates;


    int actionIndex;

    [SerializeField] Image timerImage;
    [SerializeField] GameObject bookObject;
    [SerializeField] float timer;
    [SerializeField] BookManager instructions;
    [SerializeField] TextMeshProUGUI description;
    float maxTimer;

    public int failures;

    bool active;
    bool failed;
    bool completed;

    [SerializeField] string currentAct;
    [SerializeField] string nextAct;

    [Header("Stage References")]
    [SerializeField] Light leftLight;
    [SerializeField] HandleLight leftLightHandle;
    [SerializeField] Light rightLight;
    [SerializeField] HandleLight rightLightHandle;
    [SerializeField] Light centerLight;
    [SerializeField] HandleLight centerLightHandle;


    [SerializeField] GameObject bar1;
    [SerializeField] GameObject bar2;
    [SerializeField] GameObject bar3;
    [SerializeField] GameObject smoke;

    [SerializeField] MeshRenderer background;
    [SerializeField] Background backgroundHandle;
    [SerializeField] Material churchMaterial;
    [SerializeField] Material castleMaterial;
    [SerializeField] Material pantheonMaterial;

    [SerializeField] Animator characterAnimations;
    [SerializeField] Animator curtainAnimations;


    [SerializeField] AudioSource victoryJingle;
    [SerializeField] AudioSource failureJingle;

    [SerializeField] Animator fade;

    [Header("HUD Animations")]
    [SerializeField] StopwatchAnim stopWatch;
    [SerializeField] GameObject fail;
    [SerializeField] GameObject correct;
    [SerializeField] GameObject actStart;

    private void Awake()
    {
        instance = this;
        currentStageStates = new StageState();

        InitialSettings();
        active = false;

        actStart.gameObject.SetActive(true);
        maxTimer = desiredStageStates[actionIndex].timer;
        timer = maxTimer;
        timerImage.fillAmount = 1;
        Invoke("BeginScene", 7f);
    }

    
    public void InitialSettings()
    {
        SetProps(bar1, beginningStageState.bar1Active);
        SetProps(bar2, beginningStageState.bar2Active);
        SetProps(bar3, beginningStageState.bar3Active);
        SetProps(smoke, beginningStageState.smokeActive);

        SetLights(leftLight, beginningStageState.leftLightIntensity, beginningStageState.leftLightColor);
        SetLights(centerLight, beginningStageState.centerLightIntensity, beginningStageState.centerLightColor);
        SetLights(rightLight, beginningStageState.rightLightIntensity, beginningStageState.rightLightColor);


        switch (beginningStageState.background)
        {
            case 0:
                background.material = churchMaterial;
                break;
            case 1:
                background.material = castleMaterial;
                break;
            case 2:
                background.material = pantheonMaterial;
                break;
            default:
                break;
        }

        backgroundHandle.InitialSlider(beginningStageState.background);

        currentStageStates = beginningStageState;

        description.SetText(beginningStageState.currentStageDescription);
    }

    public void SetProps(GameObject prop, bool state)
    {
        if (prop == null)
            return;
        if (state)
            prop.SetActive(true);
        else
            prop.SetActive(false);
    }
    public void SetLights(Light light, LightIntensity intensity, LightColor color)
    {
        switch (color)
        {
            case LightColor.white:
                light.color = Color.white;
                break;
            case LightColor.blue:
                light.color = Color.blue;
                break;
            case LightColor.purple:
                light.color = Color.magenta;
                break;
            case LightColor.red:
                light.color = Color.red;
                break;
            default:
                break;
        }

        switch (intensity)
        {
            case LightIntensity.off:
                light.intensity = 0;
                break;
            case LightIntensity.medium:
                light.intensity = 10;
                break;
            case LightIntensity.high:
                light.intensity = 30;
                break;
            default:
                break;
        }

        leftLightHandle.SetInitialLightSettings(color, intensity);
        centerLightHandle.SetInitialLightSettings(color, intensity);
        rightLightHandle.SetInitialLightSettings(color, intensity);

    }
    public void Update()
    {
        if (active)
        {
            if (!failed && !completed)
            {
                timer -= Time.deltaTime;
                timerImage.fillAmount -= 1f / maxTimer * Time.deltaTime;

                if (timer <= 0)
                {
                    stopWatch.Disappear();

                    if (!CheckDesiredState())
                    {
                        failureJingle.Play();
                        fail.gameObject.SetActive(true);
                        AddFailure();
                    }
                    else
                    {
                        victoryJingle.Play();
                        correct.gameObject.SetActive(true);                        
                    }

                    actionIndex++;
                    active = false;

                    if (actionIndex >= desiredStageStates.Count)
                    {
                        CompleteAct();
                    }
                    else
                    {
                        Invoke("ResetTimer", 2f);
                    }
                    
                }

            }
        }
    }

    public void CompleteAct()
    {
        completed = true;
        characterAnimations.SetTrigger("end");
        Invoke("CloseCurtain", 1f);
        Invoke("Fade", 2f);
        Invoke("LoadNextScene", 3f);
    }

    public void CloseCurtain()
    {
        curtainAnimations.SetTrigger("in");

    }
    public void Fade()
    {
        fade.SetTrigger("fadeIn");

    }
    public void BeginScene()
    {
        stopWatch.gameObject.SetActive(true);
        characterAnimations.gameObject.SetActive(true);
        characterAnimations.SetInteger("index", actionIndex);
        description.SetText(desiredStageStates[actionIndex].currentStageDescription);
        instructions.NextInstruction(actionIndex);
        Invoke("ActivateTimer", 1.5f);
    }

    public void ActivateTimer()
    {
        active = true;
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
        if (current.smokeActive != desired.smokeActive)
            return false;
        if (current.music != desired.music)
            return false;
        if (current.soundEffect != desired.soundEffect)
            return false;

        if (current.leftLightIntensity != desired.leftLightIntensity)
        {
            return false;
        }
        else
        {
            if (current.leftLightColor != desired.leftLightColor && current.leftLightIntensity != LightIntensity.off)
                return false;
        }

        if (current.rightLightIntensity != desired.rightLightIntensity)
        {
            return false;
        }
        else
        {
            if (current.rightLightColor != desired.rightLightColor && current.rightLightIntensity != LightIntensity.off)
                return false;
        }

        if (current.centerLightIntensity != desired.centerLightIntensity )
        {
            return false;
        }
        else
        {
            if (current.centerLightColor != desired.centerLightColor && current.centerLightIntensity != LightIntensity.off)
                return false;
        }
        
        
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
            case 4:
                currentStageStates.smokeActive = toggle;
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

        if (failures >= 2)
        {
            failed = true;
            curtainAnimations.SetTrigger("in");
            Debug.Log("Game Over");
            Invoke("Fade", 1f);
            Invoke("ReloadCurrentScene", 3f);

        }
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentAct);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextAct);
    }
    public void ResetTimer()
    {
        if(actionIndex < desiredStageStates.Count)
        {
            maxTimer = desiredStageStates[actionIndex].timer;
            timer = maxTimer;
            timerImage.fillAmount = 1;
            Debug.Log("Reseting timer");
            BeginScene();
        }

    }

}
