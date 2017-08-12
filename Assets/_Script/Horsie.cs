using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horsie : MonoBehaviour {

	public Vector3 MovementScale = new Vector3 ();
	public Vector3 MovementSpeed = new Vector3 ();

	public Vector3 RotationScale = new Vector3 ();
	public Vector3 RotationSpeed = new Vector3 ();

	private Vector3 RootPosition;
	private Quaternion RootRotation;

	public AudioSource EatingSound;

	// Use this for initialization
	void Start () {
		RootPosition = this.transform.position;
		RootRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = RootPosition + new Vector3 (
			MovementScale.x * Mathf.Sin (MovementSpeed.x * Time.time),
			MovementScale.y * Mathf.Sin (MovementSpeed.y * Time.time),
			MovementScale.z * Mathf.Sin (MovementSpeed.z * Time.time)
		);

		this.transform.rotation = RootRotation * Quaternion.Euler(
			RotationScale.x * Mathf.Sin (RotationSpeed.x * Time.time),
			RotationScale.y * Mathf.Sin (RotationSpeed.y * Time.time),
			RotationScale.z * Mathf.Sin (RotationSpeed.z * Time.time)
		);
	}

	public void Eat(GameObject food) {
		Debug.Log ("Horsie ate the " + food.name);
		food.SetActive (false);
		if (EatingSound) {
			EatingSound.Play ();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Horsie's mouth collided with " + collision.gameObject.name);

	}
}
