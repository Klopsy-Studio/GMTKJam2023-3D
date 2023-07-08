using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherAnimations : MonoBehaviour
{
    [SerializeField] Animator motherAnimations;
    public void SetNewPoseMother(string newPose)
    {
        ExitPose();
        motherAnimations.SetTrigger(newPose);
    }

    public void ExitPose()
    {
        motherAnimations.SetTrigger("out");
    }
}
