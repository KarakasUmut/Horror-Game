using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changing : MonoBehaviour
{
    public GameObject Gun;
    public GameObject L�ght;
  
    void Update()
    {
        ChangingWeapon();
    }

    public void ChangingWeapon()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Gun.SetActive(true);
            L�ght.SetActive(false);
           
           
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            L�ght.SetActive(true);
            Gun.SetActive(false);

        }
    }
}
