using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] MeshRenderer backgroundRenderer;
    [SerializeField] int index;
    [SerializeField] Material backgroundToChange;
    

    public void ChangeBackground()
    {
        backgroundRenderer.material = backgroundToChange;
        PlayManager.instance.ChangeBackground(index);
    }
}
