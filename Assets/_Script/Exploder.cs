using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour {

	public List<ParticleSystem> ExplosionParticleSystems;
	public List<MeshRenderer> myRenderers;

	public RandomAudioClip randomAudioClip;

	// Use this for initialization
	void Start () {
		myRenderers.AddRange(GetComponentsInChildren<MeshRenderer> ());
		myRenderers.Add (GetComponent<MeshRenderer> ());
		ExplosionParticleSystems.AddRange(GetComponentsInChildren<ParticleSystem> ());
		randomAudioClip = GetComponent<RandomAudioClip> ();
	}

	public void Reset() {

		foreach (MeshRenderer r in myRenderers) {
			if (r) {
				r.enabled = true;
			}
		}

		foreach (ParticleSystem p in ExplosionParticleSystems) {
			if (p.isPlaying)
				p.Stop ();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		//Debug.Log (this.name + " collided with " + collision.gameObject.name);

		foreach (MeshRenderer r in myRenderers) {
			if (r) {
				r.enabled = false;
			}
		}

		foreach (ParticleSystem p in ExplosionParticleSystems) {
			if (!p.isPlaying)
				p.Play();
		}

		if (randomAudioClip) {
			randomAudioClip.Play ();
		}

        // big win
        GameStateManager.Instance.AdjustSaturation(+0.1f);	// Was: 0.2f
	}
}
