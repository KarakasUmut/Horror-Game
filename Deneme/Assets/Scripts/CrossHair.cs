using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    public GameObject RayOut2;
    public Image Cross_Hair;


    void Start()
    {
        Cross_Hair = GameObject.Find("CrossHair").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        CrossHairRenk();
    }
    public void CrossHairRenk()
    {
        RaycastHit hit;
        if (Physics.Raycast(RayOut2.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Zombie"))
            {
                Cross_Hair.color = Color.red;
            }
            else
            {
                Cross_Hair.color = Color.white;
            }

        }
    }
}
