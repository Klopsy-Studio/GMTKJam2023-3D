using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomeoAnimations : MonoBehaviour
{
    [SerializeField] Animator romeoAnimations;


    public void SetNewPoseRomeo(string newPose)
    {
        ExitPose();
        romeoAnimations.SetTrigger(newPose);
    }

    public void ExitPose()
    {
        romeoAnimations.SetTrigger("out");

    }
}
