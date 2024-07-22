using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public GameObject Player;
    public AudioSource DoorSound;
  

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            animator.SetBool("Girdi", true);
            DoorSound.Play();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Girdi", false);
        DoorSound.Play();

    }
        
}
