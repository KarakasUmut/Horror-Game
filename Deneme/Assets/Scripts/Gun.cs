using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Gun : MonoBehaviour
{
    [Header("Partikül")]
    public ParticleSystem MuzzleFire;
    public ParticleSystem MermiIzi;
    public ParticleSystem Blood;

    [Header("GameObject")]
    public GameObject RayOut;
    public GameObject shell;
    public GameObject bulletDropPoint;
   

    [Header("Sesler")]
    public AudioSource ReloadSound;
    public AudioSource GunSound;
    public AudioSource NoAmmo;
    public AudioSource Holster;

    [Header("Bool&Ýnt")]
    public bool GunDraw;
    private bool canShoot = true;
    public bool CanHit = false;
    public int ToplamMermiSayýsý;
    public int SarjorKapasitesi;
    public int KalanMermi;
  

    [Header("UI")]
    public Image CrossHair;
    public TextMeshProUGUI ToplamMermiText;
    public TextMeshProUGUI KalanMermiText;
    public TextMeshPro E_text;

    
    public Animator Animator;


    void Start()
    {
        KalanMermi = SarjorKapasitesi;
        SarjorDoldurma("NormalYaz");
       
        GunSound = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SilahTemelleri();
        CrossHairRenk();
       

    }
    
    public void HolsterSound()
    {
        Holster.Play();
    }
    public void Gun_Sound()
    {
        GunSound.Play();
    }
    public void GunFýre()
    {
        MuzzleFire.Play();
    }
    public void Reload_Sound()
    {
        ReloadSound.Play();
    }
    public void SilahTemelleri()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot && KalanMermi != 0)
            {
                Animator.SetBool("AtesEt", true);
                KalanMermi--;
                KalanMermiText.text = KalanMermi.ToString();
                RaycastHit hit;
                if (Physics.Raycast(RayOut.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && CanHit == false)
                {      
                   GameObject obje = Instantiate(shell, bulletDropPoint.transform.position, bulletDropPoint.transform.rotation);
                   Rigidbody rb = obje.GetComponent<Rigidbody>();
                   rb.AddRelativeForce(new Vector3(10f, 1, 0) * 30);
                   Instantiate(MermiIzi, hit.point, Quaternion.LookRotation(hit.normal));

                }
             
            }
            if (KalanMermi == 0)
            {
                NoAmmo.Play();
            }

        }
        else
        {
            Animator.SetBool("AtesEt", false);
        }

        if (Input.GetKey(KeyCode.R))
        {
           
            StartCoroutine(Reload());
            CanHit = true;
            canShoot = false;
            StartCoroutine(FýreCooldown());
        }
        else
        {
            Animator.SetBool("Reload", false);
        

        }
        if (Input.GetKey(KeyCode.Alpha1) && !GunDraw)
        {
            Animator.SetBool("Draw", true);
            canShoot = false;
            GunDraw = true;

        }
        else
        {
            Animator.SetBool("Draw", false);
            canShoot = true;
        }
    }

    void SarjorDoldurma(string tur)
    {
        switch (tur)
        {
            case "MermiVar":
                if (ToplamMermiSayýsý <= SarjorKapasitesi)
                {
                   int ToplamDeger = KalanMermi + ToplamMermiSayýsý;
                    if (ToplamDeger > SarjorKapasitesi)
                    {
                        KalanMermi = SarjorKapasitesi;
                        ToplamMermiSayýsý = ToplamDeger - SarjorKapasitesi; 
                    }
                    else
                    {
                        KalanMermi += ToplamMermiSayýsý;
                        ToplamMermiSayýsý = 0;
                    }
                    
                }
                else
                {
                    ToplamMermiSayýsý -= SarjorKapasitesi - KalanMermi;
                    KalanMermi = SarjorKapasitesi;
                }
                
                ToplamMermiText.text = ToplamMermiSayýsý.ToString();
                KalanMermiText.text = KalanMermi.ToString();

                break;

            case "MermiYok":

                if (ToplamMermiSayýsý <= SarjorKapasitesi)
                {
                    KalanMermi = ToplamMermiSayýsý;
                    ToplamMermiSayýsý = 0;
                }
                else
                {
                    ToplamMermiSayýsý -= SarjorKapasitesi;
                    KalanMermi = SarjorKapasitesi;
                }
 
                ToplamMermiText.text = ToplamMermiSayýsý.ToString();
                KalanMermiText.text = KalanMermi.ToString();

                break;

            case "NormalYaz":
                ToplamMermiText.text = ToplamMermiSayýsý.ToString();
                KalanMermiText.text = KalanMermi.ToString();

                break;


        }
    }
    IEnumerator Reload()
    {
      
        if (KalanMermi < SarjorKapasitesi && ToplamMermiSayýsý != 0)
        {
            Animator.SetBool("Reload", true);
        }
            
        yield return new WaitForSeconds(1.5f);

        if (KalanMermi < SarjorKapasitesi && ToplamMermiSayýsý != 0)
        {
           
            if (KalanMermi != 0)
            {
                SarjorDoldurma("MermiVar");


            }
            else
            {
                SarjorDoldurma("MermiYok");
            }


        }
    }
    private IEnumerator FýreCooldown()
    {

        yield return new WaitForSeconds(1.7f);
        canShoot = true;
        CanHit = false;

    }
    public void CrossHairRenk()
    {
        RaycastHit hit;
        if (Physics.Raycast(RayOut.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Zombie"))
            {
                CrossHair.color = Color.red;
                if (Input.GetMouseButtonDown(0) && CanHit == false)
                {
                    Instantiate(Blood, hit.point, Quaternion.LookRotation(hit.normal));
                }
                


            }
            else
            {
                CrossHair.color = Color.white;
            }

        }
    }

    


}

