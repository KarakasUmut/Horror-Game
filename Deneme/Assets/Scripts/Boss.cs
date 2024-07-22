using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
  
    public GameObject canvas;
    NavMeshAgent navmesh;
    public GameObject Hedef;
    public float menzýl = 10;
   
    


    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    
        
        
    }

    private void Update()
    {
        

    }
    void LateUpdate()
    {
       
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, menzýl);
        foreach (var Objeler in hitColliders)
        {
            if (Objeler.gameObject.CompareTag("Player"))
            {
                navmesh.SetDestination(Objeler.transform.position);
                canvas.SetActive(true);
            }
        }
    }

   
	

	


   
}
