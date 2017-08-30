using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(RandomAudioClip))]
[RequireComponent(typeof(VRTK_InteractableObject))]
public class SqueakyToy : MonoBehaviour {
    private RandomAudioClip randomAudio;
    private VRTK_InteractableObject interactableObject;

    public void Start()
    {
        randomAudio = GetComponent<RandomAudioClip>();
        interactableObject = GetComponent<VRTK_InteractableObject>();
        if (interactableObject == null) Debug.Log("Skeaky without VRTK_IO in " + this.gameObject.name);
        if (randomAudio == null) Debug.Log("Skeaky without RandomAudioClip in " + this.gameObject.name);
        if (randomAudio != null && randomAudio.audioClips.Length==0) Debug.Log("Skeaky with RandomAudioClip but no clips in " + this.gameObject.name);
        interactableObject.InteractableObjectGrabbed += InteractableObject_InteractableObjectGrabbed;
    }

    private void InteractableObject_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("Item grabbed");
        randomAudio.Play();
    }
}
