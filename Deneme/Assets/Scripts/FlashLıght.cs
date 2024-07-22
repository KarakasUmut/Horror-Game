using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLıght : MonoBehaviour
{
    public Animator Anim;
    public bool Flashlıght;

   
    private void Update()
    {
        Flash_Lıght();
    }
    public void Flash_Lıght()
    {
        if (Input.GetKey(KeyCode.Alpha2) && !Flashlıght)
        {
            Anim.SetBool("FlashDraw", true);
            Flashlıght = true;
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {  
            Flashlıght = false;
            Anim.SetBool("FlashDraw", false);
        }
       

        if (Input.GetKey(KeyCode.W))
        {
            Anim.SetBool("Walk", true);
        }
        else
        {
            Anim.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Anim.SetBool("Rıght", true);
        }
        else
        {
            Anim.SetBool("Rıght", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Anim.SetBool("Left", true);
        }
        else
        {
            Anim.SetBool("Left", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Anim.SetBool("Back", true);
        }
        else
        {
            Anim.SetBool("Back", false); 
        }

    }

    
}

