using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    private Transform target;
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        //target = Camera.main.transform;  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = mainCamera.transform.position;
        transform.LookAt(pos);
        transform.forward = -transform.forward;
    }
}
