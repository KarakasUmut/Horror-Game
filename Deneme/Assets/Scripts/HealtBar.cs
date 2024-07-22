using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;


public class HealtBar : MonoBehaviour
{

    public ParticleSystem Thunder;
    public Slider Healtbar;
    public  int MaxHealt;
    public int healt;
    public GameObject RayOut2;
    public GameObject DieScreen;
    public bool Degdi = false;
    public bool DoReload = false;
    public AudioSource Laugh;
    
    


    // Start is called before the first frame update
    void Start()
    {
        healt = MaxHealt;
        Healtbar.maxValue = MaxHealt;
        Healtbar.value = healt;

    }

    // Update is called once per frame
    void Update()
    {
        EnemyBar();
        Die();
    }

    public void TakeDamege(int value)
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

    public void Die()
    {
        if (healt == 0)
        {
            DieScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            Laugh.Stop();
        }
       
    }

    public void EnemyBar()
    {
        RaycastHit hit;
        if (Physics.Raycast(RayOut2.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
           
            if (hit.collider.CompareTag("Zombie"))
            {
                Degdi = true;

                if (Input.GetMouseButtonDown(0) && Degdi == true && DoReload == false)
                {
                    TakeDamege(-10);
                    

                }
               
            }
            else
            {
                Degdi = false;
               
            }


        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            DoReload = true;
            StartCoroutine(Doreload());

        }
     
     
        
          
    }

    private IEnumerator Doreload()
    {
        yield return new WaitForSeconds(1.5f);
        DoReload = false;
    }

  
}
