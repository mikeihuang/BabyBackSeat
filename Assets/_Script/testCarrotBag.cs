using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class testCarrotBag : MonoBehaviour {

    public GameObject SpawnedObject;
    public float spawnDelay = 1f;
    public int maxCarrots = 50;
    private float spawnDelayTimer = 0f;
    private int spawnCount = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider collider)
    {
        VRTK_InteractGrab grabbingController = (collider.gameObject.GetComponent<VRTK_InteractGrab>() ? collider.gameObject.GetComponent<VRTK_InteractGrab>() : collider.gameObject.GetComponentInParent<VRTK_InteractGrab>());
        if (CanGrab(grabbingController) && Time.time >= spawnDelayTimer)
        {
            if (spawnCount < maxCarrots)
            {
                GameObject newArrow = Instantiate(SpawnedObject);
                newArrow.name = "ArrowClone";
                grabbingController.GetComponent<VRTK_InteractTouch>().ForceTouch(newArrow);
                grabbingController.AttemptGrab();
                spawnDelayTimer = Time.time + spawnDelay;
                spawnCount++;
            }
        }
    }

    private bool CanGrab(VRTK_InteractGrab grabbingController)
    {
        return (grabbingController && grabbingController.GetGrabbedObject() == null && grabbingController.IsGrabButtonPressed());
    }
}
