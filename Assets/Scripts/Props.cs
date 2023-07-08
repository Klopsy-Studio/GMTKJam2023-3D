using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour
{
    [SerializeField] int index;
    [SerializeField] GameObject currentProp;


    [SerializeField] GameObject switchOn;
    [SerializeField] GameObject switchOff;

    public void ToggleProp()
    {
        if (currentProp.activeSelf)
        {
            PlayManager.instance.ToggleBar(index, false);
            currentProp.SetActive(false);
            switchOn.gameObject.SetActive(false);
            switchOff.gameObject.SetActive(true);
        }
        else
        {
            PlayManager.instance.ToggleBar(index, true);
            switchOn.gameObject.SetActive(true);
            switchOff.gameObject.SetActive(false);
            currentProp.SetActive(true);
        }
    }

    public void Start()
    {
        CheckProp();
    }
    public void CheckProp()
    {
        if (!currentProp.activeSelf)
        {
            switchOn.gameObject.SetActive(false);
            switchOff.gameObject.SetActive(true);
        }
        else
        {
            switchOff.gameObject.SetActive(false);
            switchOn.SetActive(true);
        }
    }
}
