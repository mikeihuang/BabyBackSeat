using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;


public class ChangeScene : MonoBehaviour {

	public GameObject VRcamera;
    public GameObject SimCamera;
    VRTK_InteractableObject io;

	// Use this for initialization
	void Start () {
        io = GetComponent<VRTK_InteractableObject>();
        io.InteractableObjectGrabbed += Io_InteractableObjectGrabbed;
	}

    private void Io_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        //throw new System.NotImplementedException();
        StartCoroutine("Wait");
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("space"))
        {
            //Debug.Log("coroutine start");
            StartCoroutine("Wait");
        }

    }

	void OnTriggerEnter(Collider other){
		
		//StartCoroutine("Wait");
	
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(3);

		// Start Fading
		if (VRcamera!=null && VRcamera.activeInHierarchy) VRcamera.GetComponent<OVRScreenFade>().StartFadeOut();
        if (SimCamera != null && SimCamera.activeInHierarchy) SimCamera.GetComponent<OVRScreenFade>().StartFadeOut();

		// Wait 2 sec
		yield return new WaitForSeconds(1.98F);

		// Go to new scene
		SceneManager.LoadScene("_MASTER_SCENE");
	}


}
