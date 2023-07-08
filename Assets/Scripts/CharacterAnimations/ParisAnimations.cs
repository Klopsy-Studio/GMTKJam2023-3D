using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParisAnimations : MonoBehaviour
{
    [SerializeField] Animator parisAnimations;


    public void SetNewPoseParis(string newPose)
    {
        ExitPose();
        parisAnimations.SetTrigger(newPose);
    }

    public void ExitPose()
    {
        parisAnimations.SetTrigger("out");
    }
}
