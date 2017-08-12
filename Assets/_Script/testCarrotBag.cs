using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class testCarrotBag : VRTK_InteractableObject {

    public GameObject SpawnedObject;
    private GameObject currentObject=null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("collided  "+other.tag);
        VRTK_InteractGrab grabObject = other.GetComponent<VRTK_InteractGrab>() ? other.GetComponent<VRTK_InteractGrab>() : other.GetComponentInParent<VRTK_InteractGrab>();
        if (grabObject == null)
        {
            Debug.Log("grabObject==null");
        }
        else
        {
            if (grabObject.GetGrabbedObject() != null)
            {
                Debug.Log("grabbedObject!=null");
            }
            if (CanGrabObject(grabObject))
            {
                Debug.Log("grabbed");
                GameObject carrot = Instantiate(SpawnedObject);
                grabObject.GetComponent<VRTK_InteractTouch>().ForceTouch(carrot);
                grabObject.AttemptGrab();
            }
        }
    }

    private bool CanGrabObject(VRTK_InteractGrab grabbingObject)
    {
        return (grabbingObject != null); // && grabbingObject.GetGrabbedObject() == null && grabbingObject.gameObject.GetComponent<VRTK_ControllerEvents>().grabPressed);
    }
}
