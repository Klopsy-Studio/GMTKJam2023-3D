using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onHover;
    public UnityEvent onExit;
    public UnityEvent onClick;
    public UnityEvent onUp;

    public bool hovered;


    public void OnPointerEnter(PointerEventData eventData)
    {
        onHover.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onExit.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (hovered)
        {
            onUp.Invoke();
        }
    }

    public void EnableHover()
    {
        hovered = true;
    }

    public void DisableHover()
    {
        hovered = false;

    }


    public void Log(string message)
    {
        Debug.Log(message);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onClick.Invoke();
    }
}
