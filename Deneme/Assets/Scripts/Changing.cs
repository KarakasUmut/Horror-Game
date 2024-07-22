using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changing : MonoBehaviour
{
    public GameObject Gun;
    public GameObject Lýght;
  
    void Update()
    {
        ChangingWeapon();
    }

    public void ChangingWeapon()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Gun.SetActive(true);
            Lýght.SetActive(false);
           
           
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Lýght.SetActive(true);
            Gun.SetActive(false);

        }
    }
}
