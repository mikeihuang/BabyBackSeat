using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littleWin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider collider)
    {
        GameStateManager.Instance.AdjustSaturation(+0.1f);
    } 
}
