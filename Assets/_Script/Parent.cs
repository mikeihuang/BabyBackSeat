using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        GameStateManager.Instance.ExitImagination();

        GameStateManager.Instance.AdjustSaturation(-0.8f);
        GameStateManager.Instance.ForceSaturationSync();
    }
}
