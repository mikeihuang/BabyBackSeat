using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEatFood : MonoBehaviour {

	private AudioSource eatingSound;
	private GameObject tempFood;

	void Start(){
		eatingSound = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider food) {
		if (Time.timeSinceLevelLoad > 5F) { // Run it after 5 secs of game loading
			if (food.gameObject.tag == "Food") {

				// Reference it outside of script
				tempFood = food.gameObject;

				// Player Eating Sound
				if (eatingSound) {
					eatingSound.Play ();
				}

				// Particle Effect
				transform.Find ("FX_Heart").GetComponent<ParticleSystem> ().Play ();

				// Food set active false
				food.gameObject.SetActive (false);

				// Start timer to reappear the food
				StartCoroutine(ReAppearFood());

				// GameState
				if(Time.time>1.0f) GameStateManager.Instance.AdjustSaturation(+0.02f);
			}
		}
	}

	IEnumerator ReAppearFood(){
		yield return new WaitForSeconds (10);
		tempFood.SetActive (true);
		tempFood.transform.position = new Vector3 (0f, -1f, 0.5f);
	}
}
