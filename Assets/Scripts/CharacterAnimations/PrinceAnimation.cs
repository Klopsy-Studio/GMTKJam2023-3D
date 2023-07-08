using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinceAnimation : MonoBehaviour
{
    [SerializeField] Animator princeAnimations;


    public void SetNewPoseParis(string newPose)
    {
        ExitPose();
        princeAnimations.SetTrigger(newPose);
    }

    public void ExitPose()
    {
        princeAnimations.SetTrigger("out");
    }
}
