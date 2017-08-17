using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(RandomAudioClip))]
[RequireComponent(typeof(VRTK_InteractableObject))]
public class SqueekyToy : MonoBehaviour {
    private RandomAudioClip randomAudio;
    private VRTK_InteractableObject interactableObject;

    public void Start()
    {
        randomAudio = GetComponent<RandomAudioClip>();
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectGrabbed += InteractableObject_InteractableObjectGrabbed;
    }

    private void InteractableObject_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("Item grabbed");
        randomAudio.Play();
    }
}
