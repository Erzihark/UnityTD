using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargeting : MonoBehaviour
{
    public float range = 15f;
    public Transform target;

    public bool shouldFire;
  

        void Update()
    {
        float distance = Vector3.Distance (transform.position, target.position);

        if (distance <= range)
        {
            transform.LookAt(target);
            shouldFire = true;
        }
        else
        {
            shouldFire = false;
        }
    }
}
