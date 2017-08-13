using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

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

		SceneManager.LoadScene("_MASTER_SCENE");
	}


}
