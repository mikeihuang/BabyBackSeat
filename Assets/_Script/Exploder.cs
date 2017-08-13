using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour {

	public ParticleSystem ExplosionParticleSystem;
	public List<MeshRenderer> myRenderers;

	public RandomAudioClip randomAudioClip;

	// Use this for initialization
	void Start () {
		myRenderers.AddRange(GetComponentsInChildren<MeshRenderer> ());
		myRenderers.Add (GetComponent<MeshRenderer> ());
		ExplosionParticleSystem = GetComponentInChildren<ParticleSystem> ();
		randomAudioClip = GetComponent<RandomAudioClip> ();
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

		if (randomAudioClip) {
			randomAudioClip.Play ();
		}

        // big win
        GameStateManager.Instance.AdjustSaturation(+0.2f);
	}
}
