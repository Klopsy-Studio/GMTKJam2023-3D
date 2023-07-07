using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour
{
    [SerializeField] int index;
    [SerializeField] GameObject currentProp;
    

    public void ToggleProp()
    {
        if (currentProp.activeSelf)
        {
            PlayManager.instance.ToggleBar(index, false);
            currentProp.SetActive(false);
        }
        else
        {
            PlayManager.instance.ToggleBar(index, true);

            currentProp.SetActive(true);
        }
    }
}
