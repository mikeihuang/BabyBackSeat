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

    private AudioSource audio;

    private void Start()
    {
        _instance = this;
        audio = GetComponent<AudioSource>();
    }

    public void ExitImagination()
    {
        SaturationChange.isBlackAndWhite = true;
        CarAnimator.SetBool("TurnAround", true);
        //audio.Play();
    }

    public void StartImagination()
    {
        SaturationChange.isBlackAndWhite = false;
        Horse.Show();
    }
}
