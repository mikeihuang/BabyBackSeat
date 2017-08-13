using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;

    public static GameStateManager Instance
    {
        get { return _instance; }
    }

    public CamSaturationChange SaturationChange;
    public CamSaturationChange SimSaturationChange;
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
    }

    private void Update()
    {
        music.volume = (SaturationChange.satActual - 0.3f) / 0.7f;
        if (!music.isPlaying)
        {
            randomMusic.Play();
        }
    }

    public void ExitImagination()
    {
        StartCoroutine(exitImagination());
    }

    private IEnumerator exitImagination()
    {
        Horse.Hide();
        SaturationChange.isBlackAndWhite = true;
        if (SimSaturationChange != null) SaturationChange.isBlackAndWhite = true;
        CarAnimator.SetBool("TurnAround", true);
        AdultAudio.Play();
        yield return new WaitForSeconds(1.5f);
        CarAnimator.SetBool("TurnAround", false);
    }

    public void StartImagination()
    {
        SaturationChange.isBlackAndWhite = false;
        if (SimSaturationChange != null) SimSaturationChange.isBlackAndWhite = false;
        Horse.Show();
    }

    public void AdjustSaturation(float delta)
    {
        if (SaturationChange != null) SaturationChange.AdjustSaturation(delta);
        if (SimSaturationChange != null) SimSaturationChange.AdjustSaturation(delta);
    }

    public void ForceSaturationSync()
    {
        if (SaturationChange != null) SaturationChange.ForceSaturationSync();
        if (SimSaturationChange != null) SimSaturationChange.ForceSaturationSync();
    }
}
