using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSound : MonoBehaviour
{
    public AudioSource Holster;

    public void FlahDrawSound()
    {
        Holster.Play();
    }
}
