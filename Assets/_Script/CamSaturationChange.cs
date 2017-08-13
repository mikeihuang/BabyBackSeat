using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class CamSaturationChange : MonoBehaviour {

	[Header("Post Processing Profile")]
	PostProcessingBehaviour filters;
	PostProcessingProfile profile;

	[Header("Boolean")]
	public bool isBlackAndWhite = false;
    public bool useFlag;

	[Header("Color Change Speed")]
	public float speed = 0.01F;
    public float satChaseRate = 0.6f;

    [Header("Saturation Limits")]
    public float minSaturation;
    public float maxSaturation; 

    public float satValue;
    public float satActual;

	void Awake () {
		filters = GetComponent<PostProcessingBehaviour> ();
		profile = filters.profile;
        satValue = 1.0f;
        satActual = 1.0f;
	}

    public void AdjustSaturation(float delta)
    {
        //Debug.Log(string.Format("sat value pre {0}", satValue));
        satValue = satValue + delta;
        if (satValue < minSaturation) satValue = minSaturation;
        if (satValue > maxSaturation) satValue = maxSaturation;
        //Debug.Log(string.Format("sat adjust {0} to {1}", delta, satValue));
        //Debug.Log(string.Format("sat value post {0}", satValue));
    }
    public void ForceSaturationSync()
    {
        satActual = satValue;
    }

	void Update (){
        //Debug.Log("Sat Update");
        if (useFlag)
        {
            if (isBlackAndWhite == true)
            {
                if (profile.colorGrading.settings.basic.saturation > 0F)
                {
                    ColorGradingModel.Settings ColorSet = profile.colorGrading.settings;
                    ColorSet.basic.saturation = ColorSet.basic.saturation - speed * Time.deltaTime;
                    profile.colorGrading.settings = ColorSet;
                }
            }
            else
            {
                if (profile.colorGrading.settings.basic.saturation < 1F)
                {
                    ColorGradingModel.Settings ColorSet = profile.colorGrading.settings;
                    ColorSet.basic.saturation = ColorSet.basic.saturation + speed * Time.deltaTime;
                    profile.colorGrading.settings = ColorSet;
                }
            }
        }
        else
        {
            ColorGradingModel.Settings ColorSet = profile.colorGrading.settings;
            satValue -= speed * Time.deltaTime;
            if (satValue < minSaturation) satValue = minSaturation;
            if (satValue > maxSaturation) satValue = maxSaturation;
            satActual += (satValue - satActual) * satChaseRate * Time.deltaTime;
            ColorSet.basic.saturation = satActual;
            //Debug.Log(string.Format("Sat: {0}", satValue));
            profile.colorGrading.settings = ColorSet;
        }
	}
}
