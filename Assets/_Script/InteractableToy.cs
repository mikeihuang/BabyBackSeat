using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableToy : VRTK_InteractableObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnInteractableObjectGrabbed(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectGrabbed(e);
        Debug.Log("Item grabbed");
    }
}
