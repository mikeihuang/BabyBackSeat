using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public GameObject VRcamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		
		StartCoroutine("Wait");
	
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(3);

		// Start Fading
		VRcamera.GetComponent<OVRScreenFade>().StartFadeOut();

		// Wait 2 sec
		yield return new WaitForSeconds(1.98F);

		// Go to new scene
		SceneManager.LoadScene("_MASTER_SCENE");
	}


}
