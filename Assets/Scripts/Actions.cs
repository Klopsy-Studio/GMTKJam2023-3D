using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] string action;
    [SerializeField] SoundTone tone;
    [SerializeField] SoundType type;

    [SerializeField] GameObject buttonOn;
    [SerializeField] GameObject buttonOff;

    public void Start()
    {
        if(buttonOff != null)
        {
            buttonOff.gameObject.SetActive(false);
        }
    }
    public void RecordAction()
    {
        switch (type)
        {
            case SoundType.music:
                PlayManager.instance.ChangeMusicTone(tone);
                break;
            case SoundType.sound:
                PlayManager.instance.ChangeSoundEffectTone(tone);
                break;
            default:
                break;
        }
    }
}
