using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;

    [Header("Boolean")]
    public bool isBlackAndWhite = false;
    public bool useFlag;

    [Header("Color Change Speed")]
    public float speed = 0.1F;
    public float initSpeed = 0.2f;
    public float initDuration = 3.0f;
    public float satChaseRate = 0.85f;

    [Header("Saturation Limits")]
    public float initialSaturation = 0.4f;
    public float minSaturation = 0.1f;
    public float maxSaturation = 1.0f;

    public float satValue;
    public float satActual;


    public static GameStateManager Instance
    {
        get { return _instance; }
    }

    //public CamSaturationChange SaturationChange;
    //public CamSaturationChange SimSaturationChange;
    public Animator CarAnimator;
    public Horsie Horse;
    public RandomAudioClip AdultAudio;

    private AudioSource music;
    private RandomAudioClip randomMusic;
    

    private void Start()
    {
        _instance = this;
        music = GetComponent<AudioSource>();
        randomMusic = GetComponent<RandomAudioClip>();
        satValue = initialSaturation;
        satActual = initialSaturation;

    }

    private void Update()
    {
        music.volume = (satActual - 0.3f) / 0.7f;
        if (!music.isPlaying)
        {
            randomMusic.Play();
        }

        // adjust saturation
        //Debug.Log("Sat Update");
        if (useFlag)
        {
            if (isBlackAndWhite == true)
            {
                if (satValue > 0F)
                {
                    satValue -= speed * Time.deltaTime;
                }
            }
            else
            {
                if (satValue < 1F)
                {
                    satValue += speed * Time.deltaTime;
                }
            }
        }
        else
        {
            if (Time.timeSinceLevelLoad < initDuration)
            {
                // change to ensure initial value doesn't change 
                //satValue -= initSpeed * Time.deltaTime;
                satValue = initialSaturation;
            }
            else
            {
                satValue -= speed * Time.deltaTime;
            }
            if (satValue < minSaturation) satValue = minSaturation;
            if (satValue > maxSaturation) satValue = maxSaturation;
            satActual += (satValue - satActual) * satChaseRate * Time.deltaTime;
        }
    }

    public void ExitImagination()
    {
        StartCoroutine(exitImagination());
    }

    private IEnumerator exitImagination()
    {
        Horse.Hide();
        isBlackAndWhite = true;
        CarAnimator.SetBool("TurnAround", true);
        AdultAudio.Play();
        yield return new WaitForSeconds(1.5f);
        CarAnimator.SetBool("TurnAround", false);
    }

    public void StartImagination()
    {
        isBlackAndWhite = false;
        Horse.Show();
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
}
