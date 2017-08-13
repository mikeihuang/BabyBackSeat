using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableToy : VRTK_InteractableObject {
    RandomAudioClip randomAudio;

   
    public override void  OnInteractableObjectGrabbed(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectGrabbed(e);
        Debug.Log("Item grabbed");
        GetComponent<RandomAudioClip>().Play();

    }
}
