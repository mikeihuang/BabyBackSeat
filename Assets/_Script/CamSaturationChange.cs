using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class CamSaturationChange : MonoBehaviour {

	[Header("Post Processing Profile")]
	PostProcessingBehaviour filters;
	PostProcessingProfile profile;


	void Awake () {
		filters = GetComponent<PostProcessingBehaviour> ();
		profile = filters.profile;
	}

 	void Update (){
        ColorGradingModel.Settings ColorSet = profile.colorGrading.settings;
        ColorSet.basic.saturation = GameStateManager.Instance.satActual;
        profile.colorGrading.settings = ColorSet;

	}
}
