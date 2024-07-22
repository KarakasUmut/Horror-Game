using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellManager : MonoBehaviour
{
    
    public AudioSource ShellDropSound;
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ShellDropSound.Play();

            if (!ShellDropSound.isPlaying)
            {
                
            }
        }
    }
}
