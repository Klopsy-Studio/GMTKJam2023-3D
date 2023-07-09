using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActStartAnim : MonoBehaviour
{
    [SerializeField] private GameObject newAct;
    [SerializeField] private GameObject countdown3;
    [SerializeField] private GameObject countdown2;
    [SerializeField] private GameObject countdown1;
    [SerializeField] private GameObject action;

    private void OnEnable()
    {
        newAct.SetActive(true);

        newAct.transform.DOPunchScale(new Vector3(1, 1, 1), 1, 5, 0.1f).OnComplete(() =>
        {
            newAct.transform.DOShakePosition(2.5f, 10, 20).OnComplete(() =>
            {
                newAct.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f).SetEase(Ease.InOutCubic).OnComplete(() =>
                {
                    newAct.SetActive(false);
                    newAct.transform.localScale = new Vector3(1, 1, 1);
                    StartCoroutine(Countdown());
                });
            });
        });
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.2f);

        countdown3.SetActive(true);
        countdown3.transform.DOScale(new Vector3(1, 1, 1), 0.1f);

        yield return new WaitForSeconds(0.2f);

        countdown3.SetActive(false);
        countdown3.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        countdown2.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        countdown2.SetActive(false);
        countdown1.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        action.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f).OnComplete(() =>
        {
            countdown1.SetActive(false);
            ActionStart();
        });
        
    }

    private void ActionStart()
    {
        action.SetActive(true);
        action.transform.DOScale(new Vector3(1, 1, 1), 0.1f).OnComplete(() =>
        {
            action.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.7f).OnComplete(() =>
            {
                action.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f).SetEase(Ease.InOutCubic).OnComplete(() =>
                {
                    action.SetActive(false);
                    action.transform.localScale = new Vector3(1, 1, 1);
                });
            });
        });
    }



}
