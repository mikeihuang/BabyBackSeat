using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour {

	public ParticleSystem ExplosionParticleSystem;
	public List<MeshRenderer> myRenderers;

	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		myRenderers.AddRange(GetComponentsInChildren<MeshRenderer> ());
		myRenderers.Add (GetComponent<MeshRenderer> ());
		ExplosionParticleSystem = GetComponentInChildren<ParticleSystem> ();
		audioSource = GetComponent<AudioSource> ();
	}

	public void Reset() {

		foreach (MeshRenderer r in myRenderers) {
			if (r) {
				r.enabled = true;
			}
		}

		if (ExplosionParticleSystem) {
			if (ExplosionParticleSystem.isPlaying) {
				ExplosionParticleSystem.Stop ();
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log (this.name + " collided with " + collision.gameObject.name);

		foreach (MeshRenderer r in myRenderers) {
			if (r) {
				r.enabled = false;
			}
		}

		if (ExplosionParticleSystem) {
			ExplosionParticleSystem.Play ();
		}

		if (audioSource) {
			audioSource.Play ();
		}
	}
}
