using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Horror : MonoBehaviour
{
    public GameObject Player;
    public Canvas Canvas;
    private BoxCollider Kutu;
    public AudioSource Zort;

    void Start()
    {
       Kutu = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Canvas.gameObject.SetActive(true);
            Zort.Play();
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Kutu.gameObject.SetActive(false);
        }
    }

}
