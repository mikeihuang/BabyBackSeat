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
            //GameStateManager.Instance.SaturationChange.Adjust(+0.5f);
        }

	} // End of Update

    // also handle lightening the mood when we bounce
    private void OnTriggerEnter(Collider collider)
    {
        GameStateManager.Instance.AdjustSaturation(+0.02f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameStateManager.Instance.AdjustSaturation(+0.02f);
    }

} // End
