using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FailAnim : MonoBehaviour
{
    public Vector3 finalScale;

    private void OnEnable()
    {
        transform.DOPunchScale(finalScale, 1, 5, 0.1f);
        StartCoroutine(Disappear());
    }


    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1f);

        transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f).SetEase(Ease.InOutCubic).OnComplete(() =>
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.localScale = finalScale;
        });
    }
}
