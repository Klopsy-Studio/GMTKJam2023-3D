using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JulietaAnimations : MonoBehaviour
{
    [SerializeField] Animator julietaAnimations;


    public void SetNewPoseJulieta(string newPose)
    {
        ExitPose();
        julietaAnimations.SetTrigger(newPose);
    }

    public void ExitPose()
    {
        julietaAnimations.SetTrigger("out");

    }
}
