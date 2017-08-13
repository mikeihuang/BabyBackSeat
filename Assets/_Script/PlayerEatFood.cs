using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEatFood : MonoBehaviour {

	private AudioSource eatingSound;

	void Start(){
		eatingSound = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider food) {
		if (Time.timeSinceLevelLoad > 5F) { // Run it after 5 secs of game loading
			if (food.gameObject.tag == "Food") {

				// Player Eating Sound
				if (eatingSound) {
					eatingSound.Play ();
				}

				// Particle Effect
				transform.Find ("FX_Heart").GetComponent<ParticleSystem> ().Play ();

				// Instantiate new food

				Instantiate (food, new Vector3 (0f, 0f, 0.5f), Quaternion.identity);

				// Food set active false
				food.gameObject.SetActive (false);

				// Destroy Food
				Destroy (food);
			}
		}
	}
}
