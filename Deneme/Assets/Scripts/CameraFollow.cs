using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float chaseSpeed = 5;
    void Start()
    {
        if (!target)
        {
            
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, chaseSpeed * Time.deltaTime);
    }
}
