using UnityEngine;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;
using System.Collections.Specialized;
using UnityEngine.UIElements;

[RequireComponent(typeof(Button))]
public class MobileCameraControlBackup : MonoBehaviour
{

    private static readonly float PanSpeed = 10f;
    private static readonly float RotateSpeed = 0.2f;


    private static float BoundsX1 = -1f;
    private static float BoundsX2 = 0f;

    private static float BoundsY1 = -19f;
    private static float BoundsY2 = -2f;

    private  float[] BoundsX = new float[] { BoundsX1, BoundsX2 };
    private  float[] BoundsZ = new float[] { BoundsY1, BoundsY2 };

    private Camera cam;
    public GameObject target;
    public static int CurrentPosition; // 0 = far out, 1=zoomed in hexes. 2=zoomed in lane
    private float CurrentFOV;
    public bool zoomingin;
    public bool zoomingout;
    private Vector3 lastPanPosition;
    private int panFingerId; // Touch mode only
    private float zoomTimer;

    public static bool cantPan;
    public static bool gameEnd;

    private bool isTouch;

    void Start()
    {
        CurrentPosition = 0;
        Screen.SetResolution(1280, 720, true);
        // cam.aspect = 16 / 9;
    }
    void Awake()
    {
        cam = GetComponent<Camera>();

        if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer)
        {
            isTouch = true;
        }
        else
        {
            isTouch = false;
        }
    }

    void Update()
    {
        if (isTouch == true)
        {
            HandleTouch();
        }
        else
        {
            HandleMouse();
        }

        zoomTimer -= Time.deltaTime;

        CurrentFOV = cam.fieldOfView;

        if (CurrentPosition == 0 && CurrentFOV >= 80f)
        {
            zoomingout = false;
            zoomingin = false;
        }
        else if (CurrentPosition == 1 && CurrentFOV <= 55.5f && CurrentFOV >= 55f)
        {
            zoomingin = false;
            zoomingout = false;
        }
        else if (CurrentPosition == 2 && CurrentFOV <= 37f && CurrentFOV >= 36f)
        {
            zoomingin = false;
            zoomingout = false;
        }
        else  if (CurrentPosition == 3 && CurrentFOV >= 80f)
        {
            zoomingout = false;
            zoomingin = false;
        }

        if (CurrentPosition == 0 && zoomingout == true) //Going from Position 1 to Position 0
        {
            Vector3 StartPosition = cam.transform.position;

            Vector3 move = new Vector3(0f, 18.5f, -7f);

            cam.transform.position = Vector3.Lerp(StartPosition, move, 0.3f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80.5f, 0.3f);
        }
        else if (CurrentPosition == 1 && zoomingin == true) //Going from Position 0 to Position 1
        {
            Vector3 StartPosition = cam.transform.position;

            Vector3 move = new Vector3(0f, 18.5f, -7f);

            cam.transform.position = Vector3.Lerp(StartPosition, move, 0.3f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 55.2f, 0.3f);

        }
        else if (CurrentPosition == 1 && zoomingout == true) //Going from Position 2 to Position 1
        {
            Vector3 StartPosition = cam.transform.position;

            Vector3 move = new Vector3(0f, 18.5f, -7f);

            cam.transform.position = Vector3.Lerp(StartPosition, move, 0.3f);

            Quaternion StartRotation = cam.transform.rotation;

            Quaternion rotate = Quaternion.Euler(70f, 0f, 0f);

            cam.transform.rotation = Quaternion.Lerp(StartRotation, rotate, 0.3f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 55.2f, 0.3f);
        }
        else if (CurrentPosition == 2 && zoomingin == true) //Going from Position 1 to Position 2
        {
            Vector3 StartPosition = cam.transform.position;

            Vector3 move = new Vector3(0f, 18.5f, -7f);

            cam.transform.position = Vector3.Lerp(StartPosition, move, 0.3f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 36.5f, 0.3f);
        }
        else if (CurrentPosition == 2 && zoomingout == true) //Going from Position 3 to Position 2
        {
             Vector3 StartPosition = cam.transform.position;

             Vector3 move = new Vector3(0f, 18.5f, -7f);

             cam.transform.position = Vector3.Lerp(StartPosition, move, 0.3f);

             Quaternion StartRotation = cam.transform.rotation;

             Quaternion rotate = Quaternion.Euler(70f, 0f, 0f);

             cam.transform.rotation = Quaternion.Lerp(StartRotation, rotate, 0.3f);

             cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 36.5f, 0.3f);
        }
        else if (CurrentPosition == 3 && zoomingin == true) //Going from Position 2 to Position 3
        {
            Quaternion StartRotation = cam.transform.rotation;

            Quaternion rotate1 = Quaternion.Euler(15f, 0f, 0f);

            cam.transform.rotation = Quaternion.Lerp(StartRotation, rotate1, 0.5f);

            Vector3 StartPosition = cam.transform.position;

            Vector3 move1 = new Vector3(0f, 3f, 0f);

            cam.transform.position = Vector3.Lerp(StartPosition, move1, 0.3f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80.5f, 0.3f);
        }
    }

    public void ZoomIn()
    {    
        if (!zoomingin && !zoomingout)
        {
            if (CurrentPosition == 0 && zoomTimer <= 0)
            {
                CurrentPosition = 1;
                zoomingin = true;
                zoomTimer = 0.2f;

                BoundsX1 = -13f;
                BoundsX2 = 13f;

                BoundsY1 = -23f;
                BoundsY2 = 8f;

                BoundsX = new float[] { BoundsX1, BoundsX2 };
                BoundsZ = new float[] { BoundsY1, BoundsY2 };
            }
            else if (CurrentPosition == 1 && zoomTimer <= 0)
            {
                CurrentPosition = 2;
                zoomingin = true;
                zoomTimer = 0.2f;

                BoundsX1 = -15f;
                BoundsX2 = 15f;

                BoundsY1 = -29f;
                BoundsY2 = 15f;

                BoundsX = new float[] { BoundsX1, BoundsX2 };
                BoundsZ = new float[] { BoundsY1, BoundsY2 };
            }
            else if (CurrentPosition == 2 && zoomTimer <= 0)
            {
                CurrentPosition = 3;
                zoomingin = true;
                zoomTimer = 0.5f;

                BoundsX = new float[] { BoundsX1, BoundsX2 };
                BoundsZ = new float[] { BoundsY1, BoundsY2 };
            }
        }
    }

    public void ZoomOut()
    {
        if (!zoomingin && !zoomingout)
        {
              if (CurrentPosition == 1 && zoomTimer <= 0)
              {
                CurrentPosition = 0;
                zoomingout = true;
                zoomTimer = 0.2f;

                BoundsX1 = -1f;
                BoundsX2 = 0f;

                BoundsY1 = -19f;
                BoundsY2 = 2f;

                BoundsX = new float[] { BoundsX1, BoundsX2 };
                BoundsZ = new float[] { BoundsY1, BoundsY2 };

              }
              else if (CurrentPosition == 2 && zoomTimer <= 0)
              {
                CurrentPosition = 1;
                zoomingout = true;
                zoomTimer = 0.2f;

                BoundsX1 = -13f;
                BoundsX2 = 13f;

                BoundsY1 = -23f;
                BoundsY2 = 8f;

                BoundsX = new float[] { BoundsX1, BoundsX2 };
                BoundsZ = new float[] { BoundsY1, BoundsY2 };
              }
              else if (CurrentPosition == 3 && zoomTimer <= 0)
              {
                CurrentPosition = 2;
                zoomingout = true;
                zoomTimer = 0.2f;

                BoundsX1 = -15f;
                BoundsX2 = 15f;

                BoundsY1 = -29f;
                BoundsY2 = 15f;

                BoundsX = new float[] { BoundsX1, BoundsX2 };
                BoundsZ = new float[] { BoundsY1, BoundsY2 };
              }
        }
    }

    void HandleTouch()
    {
        switch (Input.touchCount)
        {
            case 1: // Panning
                // If the touch began, capture its position and its finger ID.
                // Otherwise, if the finger ID of the touch doesn't match, skip it.
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    lastPanPosition = touch.position;
                    panFingerId = touch.fingerId;
                }
                else if (touch.fingerId == panFingerId && touch.phase == TouchPhase.Moved)
                {
                    if (CurrentPosition == 3)
                    {
                      RotateCamera(Input.GetTouch(0).deltaPosition.x);
                    }
                    else if (!cantPan && !gameEnd)
                    {                          
                        PanCamera(touch.position);
                    }
                    
                }
                break;

        }
    }

    void HandleMouse()
    {
        // On mouse down, capture it's position.
        // Otherwise, if the mouse is still down, pan the camera.
        if (Input.GetMouseButtonDown(0))
        {
            lastPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (CurrentPosition == 3)
            {
                RotateCamera(Input.GetAxis("Mouse X"));
            }
            else if (!cantPan && !gameEnd)
            {                 
                PanCamera(Input.mousePosition);
            }    
        }
    }

    void RotateCamera(float newPanPosition)
    {
         Vector3 move = new Vector3(0, newPanPosition * RotateSpeed, 0);
         transform.Rotate(move, Space.World);
    }

    void PanCamera(Vector3 newPanPosition)
    {
        // Determine how much to move the camera
        Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
        Vector3 move = new Vector3(offset.x * PanSpeed, 0, offset.y * PanSpeed);

        // Perform the movement
        transform.Translate(move, Space.World);

        // Ensure the camera remains within bounds.
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, BoundsX[0], BoundsX[1]);
        pos.z = Mathf.Clamp(transform.position.z, BoundsZ[0], BoundsZ[1]);
        transform.position = pos;

        // Cache the position
        lastPanPosition = newPanPosition;
    }
}



