﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class testCarrotBag : VRTK_InteractableObject {

    public GameObject SpawnedObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("collieded");
        VRTK_InteractGrab grabObject = other.GetComponent<VRTK_InteractGrab>() ? other.GetComponent<VRTK_InteractGrab>() : other.GetComponentInParent<VRTK_InteractGrab>();
        if(CanGrabObject(grabObject))
        {
            Debug.Log("grabbed");
            GameObject carrot = Instantiate(SpawnedObject);
            grabObject.GetComponent<VRTK_InteractTouch>().ForceTouch(carrot);
            grabObject.AttemptGrab();
        }
    }

    private bool CanGrabObject(VRTK_InteractGrab grabbedObject)
    {
        return (grabbedObject && grabbedObject.GetGrabbedObject() == null && grabbedObject.gameObject.GetComponent<VRTK_ControllerEvents>().grabPressed);
    }
}
