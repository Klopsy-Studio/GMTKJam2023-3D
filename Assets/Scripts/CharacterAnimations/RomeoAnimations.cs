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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitPose();
            SetNewPoseRomeo("talk");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ExitPose();
            SetNewPoseRomeo("base");
        }
    }
    public void ExitPose()
    {
        romeoAnimations.SetTrigger("out");

    }
}
