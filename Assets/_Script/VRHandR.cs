using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandR : MonoBehaviour {

	void Update () {

		// Change Hand material while pressing trigger
		if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0f){
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
			//
		}
	}
}
