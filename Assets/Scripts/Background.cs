using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] MeshRenderer backgroundRenderer;
    [SerializeField] int index;
    [SerializeField] Material[] backgroundToChange;

    [SerializeField] GameObject[] sliders;

    
    public void ChangeBackground()
    {
        index++;
        if(index >= backgroundToChange.Length)
        {
            index = 0;
        }

        backgroundRenderer.material = backgroundToChange[index];
        PlayManager.instance.ChangeBackground(index);

        SetCorrectSlider(index);
    }


    public void SetCorrectSlider(int chosenIndex)
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].gameObject.SetActive(false);
        }

        sliders[chosenIndex].gameObject.SetActive(true);
    }

    public void InitialSlider(int chosenIndex)
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].gameObject.SetActive(false);
        }

        sliders[chosenIndex].gameObject.SetActive(true);

        index = chosenIndex;
    }

}
