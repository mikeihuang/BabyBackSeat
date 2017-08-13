using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioClip : MonoBehaviour {

	public AudioSource audioSource;

	public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();	
	}
	
	public void Play () {
		if (audioSource) {
			if(!audioSource.isPlaying) {
				if (audioClips.Length > 0) {
					int r = Random.Range (0, audioClips.Length);
					audioSource.clip = audioClips [r];
					audioSource.pitch = Random.Range (0.8f, 1.2f);
					audioSource.Play ();
				}
			}
		}
	}
}
