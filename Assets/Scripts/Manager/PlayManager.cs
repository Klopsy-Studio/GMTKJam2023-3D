using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    float maxTimer;

    public int failures;

    bool active;
    bool failed;
    bool completed;

    [SerializeField] string currentAct;
    [SerializeField] string nextAct;

    [Header("Stage References")]
    [SerializeField] Light leftLight;
    [SerializeField] Light rightLight;
    [SerializeField] Light centerLight;

    [SerializeField] GameObject bar1;
    [SerializeField] GameObject bar2;
    [SerializeField] GameObject bar3;
    [SerializeField] GameObject smoke;

    [SerializeField] MeshRenderer background;
    [SerializeField] Material churchMaterial;
    [SerializeField] Material castleMaterial;
    [SerializeField] Material pantheonMaterial;

    [SerializeField] Animator characterAnimations;
    [SerializeField] Animator curtainAnimations;
    private void Awake()
    {
        instance = this;
        currentStageStates = new StageState();

        InitialSettings();
        ResetTimer();
        active = false;
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
            case 1:
                background.material = churchMaterial;
                break;
            case 2:
                background.material = castleMaterial;
                break;
            case 3:
                background.material = pantheonMaterial;
                break;
            default:
                break;
        }

        currentStageStates = beginningStageState;
    }

    public void SetProps(GameObject prop, bool state)
    {
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
                    if (CheckDesiredState())
                    {
                        Debug.Log("Success");
                    }
                    else
                    {
                        AddFailure();
                    }

                    actionIndex++;

                    if (actionIndex >= desiredStageStates.Count)
                    {
                        CompleteAct();
                    }

                    ResetTimer();
                    active = false;
                }

            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && !active && !completed && !failed)
        {
            BeginScene();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (bookObject.activeSelf)
            {
                bookObject.SetActive(false);
            }

            else
            {
                bookObject.SetActive(true);
            }
        }

    }

    public void CompleteAct()
    {
        completed = true;
        curtainAnimations.SetTrigger("in");
        Invoke("LoadNextScene", 1f);
    }
    public void BeginScene()
    {
        active = true;
        characterAnimations.SetInteger("index", actionIndex);
        instructions.NextInstruction(actionIndex);
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
            if (current.leftLightColor != desired.leftLightColor)
                return false;
        }

        if (current.rightLightIntensity != desired.rightLightIntensity)
        {
            return false;
        }
        else
        {
            if (current.rightLightColor != desired.rightLightColor)
                return false;
        }

        if (current.centerLightIntensity != desired.centerLightIntensity)
        {
            return false;
        }
        else
        {
            if (current.centerLightColor != desired.centerLightColor)
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
        Debug.Log("Failure");

        if (failures >= 3)
        {
            failed = true;
            curtainAnimations.SetTrigger("in");
            Debug.Log("Game Over");

            Invoke("ReloadCurrentScene", 1f);

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
        }
        
    }

}
