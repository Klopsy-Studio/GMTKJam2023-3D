using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JulietaAnimations : MonoBehaviour
{
    [SerializeField] Animator julietaAnimations;


    public void SetNewPose(string newPose)
    {
        ExitPose();
        julietaAnimations.SetTrigger(newPose);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitPose();
            SetNewPose("talk");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ExitPose();
            SetNewPose("base");
        }
    }
    public void ExitPose()
    {
        julietaAnimations.SetTrigger("out");

    }
}
