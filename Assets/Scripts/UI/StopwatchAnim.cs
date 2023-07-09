using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StopwatchAnim : MonoBehaviour
{
    private void Start()
    {
        InitAnimation();
    }

    private void InitAnimation()
    {
        transform.DOMove(new Vector3(2, 2, 0), 1).SetEase(Ease.InOutCubic);




    }
}
