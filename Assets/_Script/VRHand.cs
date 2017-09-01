using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHand : MonoBehaviour
{

    public VRTK.VRTK_ControllerEvents ControllerEvents;

    private void Start()
    {
    }

    void Update()
    {
        if (ControllerEvents.gripPressed)
        {
            GetComponent<Animator>().SetBool("Close", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Close", false);
        }

        // Play sound for pressing the Hand Trigger
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            //
        }

        // Play sound if IndexTrigger is pressed
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {

        }
    }
}
