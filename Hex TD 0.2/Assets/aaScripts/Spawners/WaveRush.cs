using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveRush : MonoBehaviour
{
    public GameObject WaveIndicator;
    public UnityEvent OnClick = new UnityEvent();
    


    void Start()
    {
        WaveIndicator = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {


        if (WaveIndicator == enabled)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
                {
                    OnClick.Invoke();
                    GameObject[] objects = GameObject.FindGameObjectsWithTag("WaveIndicator");

                    for (int i = 0; i < objects.Length; i++)
                    {
                        Destroy(objects[i]);
                    }
                }
            }
        }
    }
}
