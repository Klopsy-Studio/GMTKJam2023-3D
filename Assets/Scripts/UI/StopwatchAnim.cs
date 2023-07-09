using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StopwatchAnim : MonoBehaviour
{
    [SerializeField] private Vector3 scale;
    [SerializeField] private Vector3 HUDPosition;

    private void OnEnable()
    {
        transform.localScale = scale;
        InitAnimation();
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }

    private void InitAnimation()
    {
        transform.DOPunchScale(new Vector3(2, 2, 2), 1, 5, 0.1f).OnComplete(() =>
        {
            transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.InOutCubic).OnComplete(() =>
            {
                transform.DOLocalMove(HUDPosition, 1).SetEase(Ease.InOutCubic);
            });
        });
    }


    public void Disappear()
    {
        transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f).SetEase(Ease.InOutCubic).OnComplete(() =>
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.localScale = scale;
        });
    }
}
