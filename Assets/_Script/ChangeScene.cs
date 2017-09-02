using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;


public class ChangeScene : MonoBehaviour {
    VRTK_InteractableObject io;
    public float fadeDelay = 3.0f;
    public float fadeDuration = 1.98f;

    // Use this for initialization
    void Start () {
        io = GetComponent<VRTK_InteractableObject>();
        io.InteractableObjectGrabbed += Io_InteractableObjectGrabbed;
	}

    private void Io_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        //throw new System.NotImplementedException();
		//Debug.Log("grabbed");
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
		//Debug.Log("coroutine started");
		yield return new WaitForSeconds(fadeDelay);
        //Debug.Log("coroutine started 2");
        // Start Fading
        OVRScreenFade fade = FindObjectOfType<OVRScreenFade>();
        fade.GetComponent<OVRScreenFade>().StartFadeOut();

		// Wait 2 sec
		yield return new WaitForSeconds(fadeDuration);

		// Go to new scene
		SceneManager.LoadScene("_MASTER_SCENE");
	}


}
