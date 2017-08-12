using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class CamColorSaturationChange : MonoBehaviour {

	[Header("Post Processing Profile")]
	PostProcessingBehaviour filters;
	PostProcessingProfile profile;

	[Header("Boolean")]
	public bool isBlackAndWhite = false;

	[Header("Color Change Speed")]
	float speed = 0.5F;

	void Start () {
		filters = GetComponent<PostProcessingBehaviour> ();
		profile = filters.profile;
	}

	void Update (){
		if (isBlackAndWhite == true) {
			if (profile.colorGrading.settings.basic.saturation > 0F) {
				ColorGradingModel.Settings ColorSet = profile.colorGrading.settings;
				ColorSet.basic.saturation = ColorSet.basic.saturation - speed * Time.deltaTime;
				profile.colorGrading.settings = ColorSet;
			}
		} else {
			if (profile.colorGrading.settings.basic.saturation < 1F) {
				ColorGradingModel.Settings ColorSet = profile.colorGrading.settings;
				ColorSet.basic.saturation = ColorSet.basic.saturation + speed * Time.deltaTime;
				profile.colorGrading.settings = ColorSet;
			}
		}
	}
}
