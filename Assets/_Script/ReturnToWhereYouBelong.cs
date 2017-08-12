using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToWhereYouBelong : MonoBehaviour {
	
	private Vector3 originalPos;
	private Quaternion originalRotation;

	void Start () {
		originalPos = transform.localPosition;
		originalRotation = transform.rotation;
	}

	void Update(){

		// Y axis reset
		if (transform.position.y < -5f) {
			transform.localPosition = originalPos;
			transform.rotation = originalRotation;
		}

	} // End of Update

} // End
