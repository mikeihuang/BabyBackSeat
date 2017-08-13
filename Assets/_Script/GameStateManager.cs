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
    public AudioSource AdultAudio;
    

    private void Start()
    {
        _instance = this;
    }

    public void ExitImagination()
    {
        Horse.Hide();
        SaturationChange.isBlackAndWhite = true;
        if (SimSaturationChange != null) SimSaturationChange.isBlackAndWhite = true;
        CarAnimator.SetBool("TurnAround", true);
        AdultAudio.Play();
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
}
