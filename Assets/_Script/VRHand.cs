using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHand : MonoBehaviour {

    VRTK.VRTK_ControllerEvents controllerEvents;

    private void Start()
    {
        controllerEvents = GetComponent<Transform>().parent.GetComponentInChildren<VRTK.VRTK_ControllerEvents>();
    }

    void Update () {

		// Change Hand material while pressing trigger
		if(controllerEvents.triggerHairlinePressed){
			GetComponent<Animator> ().SetBool ("Close", true);
		} else {
			GetComponent<Animator> ().SetBool ("Close", false);
		}

		// Play sound for pressing the Hand Trigger
		if (OVRInput.GetDown (OVRInput.Button.SecondaryHandTrigger)) {
			//
		}

		// Play sound if IndexTrigger is pressed
		if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)){
			
		}
	}
}
