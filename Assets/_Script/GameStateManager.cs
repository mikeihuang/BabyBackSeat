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
        CarAnimator.SetBool("TurnAround", true);
        AdultAudio.Play();
    }

    public void StartImagination()
    {
        SaturationChange.isBlackAndWhite = false;
        Horse.Show();
    }
}
