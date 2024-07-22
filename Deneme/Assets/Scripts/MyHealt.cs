using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyHealt : MonoBehaviour
{
    public Slider Healtbar;
    public int MaxHealt;
    public int healt;
    public AudioSource PainSound;
    
    public GameObject Died;

    void Start()
    {
        healt = MaxHealt;
        Healtbar.maxValue = MaxHealt;
        Healtbar.value = healt;
    }

    void Update()
    {
        DiedScreen();
       


    }

    public void TakeDamege2(int value)
    {
        healt += value;
        if (healt > MaxHealt)
        {
            healt = MaxHealt;
        }
        else if (healt < 0)
        {
            healt = 0;
        }
        Healtbar.value = healt;


    }

  
    public void DiedScreen()
    {
        if (healt == 0)
        {
            Died.SetActive(true);
           
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Scythe"))
        {
            TakeDamege2(-10);
            PainSound.Play();
           
        }
    }
    
    public void RestartGame()
    {
        // Oyun sahnesini yeniden yükle
        SceneManager.LoadScene(1);
     
      

    }





}
