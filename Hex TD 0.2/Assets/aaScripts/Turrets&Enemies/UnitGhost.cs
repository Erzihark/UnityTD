using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class UnitGhost : MonoBehaviour
{

    public GameObject Ghost;
    public static bool dragGhost;
    public static Material BlueTransparent;
    static readonly int materialColor = Shader.PropertyToID("_Color");
    public static Material PurpleTransparent;
    public static Material GreenTransparent;

    Collider m_collider;

    void Start()
    {
        BlueTransparent = Resources.Load("BlueTransparent", typeof(Material)) as Material;
        PurpleTransparent = Resources.Load("PurpleTransparent", typeof(Material)) as Material;
        GreenTransparent = Resources.Load("GreenTransparent", typeof(Material)) as Material;

       // BlueTransparent.color = new Color(0, 0.65f, 1, 0.75f);
        BlueTransparent.SetColor(materialColor, new Color(0, 0.65f, 1, 0.75f));

       // PurpleTransparent.color = new Color(1, 0.38f, 1, 0.75f);
        PurpleTransparent.SetColor(materialColor, new Color(1, 0.38f, 1, 0.75f));

        //GreenTransparent.color = new Color(0, 1, 0, 0.75f);
        GreenTransparent.SetColor(materialColor, new Color(0, 1, 0, 0.75f));

        Ghost = this.gameObject;
        m_collider = GetComponent<Collider>();
    }


    public static void RedGhost()
    {
        //BlueTransparent.color = new Color(1, 0, 0, 0.75f);
        BlueTransparent.SetColor(materialColor, new Color(1, 0, 0, 0.75f));

        //PurpleTransparent.color = new Color(1, 0, 0, 0.75f);
        PurpleTransparent.SetColor(materialColor, new Color(1, 0, 0, 0.75f));

        //GreenTransparent.color = new Color(1, 0, 0, 0.75f);
        GreenTransparent.SetColor(materialColor, new Color(1, 0, 0, 0.75f));
    }

    public static void NormalGhost()
    {
       // BlueTransparent.color = new Color(0, 0.65f, 1, 0.75f);
        BlueTransparent.SetColor(materialColor, new Color(0, 0.65f, 1, 0.75f));

       // PurpleTransparent.color = new Color(1, 0.38f, 1, 0.75f);
        PurpleTransparent.SetColor(materialColor, new Color(1, 0.38f, 1, 0.75f));

       // GreenTransparent.color = new Color(0, 1, 0, 0.75f);
        GreenTransparent.SetColor(materialColor, new Color(0, 1, 0, 0.75f));
    }

    void Update()
    {
        if (BuildManager.tutorialGhost)
        {
            Destroy(this.gameObject);
            BuildManager.GhostActive = false;
            dragGhost = false;
            MobileCameraControlBackup.cantPan = false;
            return;
        }


        if (Ghost == enabled)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
                {
                    dragGhost = true;                   
                }
                else
                {
                    if (Physics.Raycast(ray, out Hit) && Hit.collider.tag != "UIButtons")
                    {
                        Destroy(this.gameObject);
                        BuildManager.GhostActive = false;
                    }
                   
                }
            }
        }
        

        if (Input.GetMouseButton(0))
        {
            if (dragGhost == true)        //update Ghost position
            {
                MobileCameraControlBackup.cantPan = true;
                float planeY = 0.85f;
                Transform draggingObject = transform;

                Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                m_collider.enabled = false;

                float distance; // the distance from the ray origin to the ray intersection of the plane
                if (plane.Raycast(ray, out distance))
                {
                    draggingObject.position = ray.GetPoint(distance); // distance along the ray
                }
            }
        }
        else
        {
            NormalGhost();
            transform.position = new Vector3(-0.02f, 0.85f, 0f);
            m_collider.enabled = true;
            MobileCameraControlBackup.cantPan = false;
            dragGhost = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Destroy(this.gameObject);
            BuildManager.GhostActive = false;
            MobileCameraControlBackup.cantPan = false;
        }
     
    }


}
