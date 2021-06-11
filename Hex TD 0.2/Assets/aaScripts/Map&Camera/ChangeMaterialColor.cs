using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    Renderer rend;
    static readonly int materialColor = Shader.PropertyToID("_EmissionColor");
    private bool check80 = false;
    private bool check60 = false;
    private bool check40 = false;
    private bool check20 = false;
    private bool check0 = false;

    public static float wallCrack1 = 0;
    public static float wallCrack2 = 0;
    public static float wallCrack3 = 0;
    public static float wallCrack4 = 0;
    public static float wallCrack5 = 0;
    public static float wallCrack6 = 0;

    public int wallIndex;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    void Update()
    {
        Health healthScript = transform.gameObject.GetComponent<Health>();

        if (healthScript.cur_health < 400 && healthScript.cur_health > 300 && check80 == false)
        {
            rend.material.SetColor(materialColor, new Color(0.3189f, 3.245283f, 0, 2));
            switch (wallIndex)
            {
                case 1:
                    wallCrack1 = 0.20f;
                    break;
                case 2:
                    wallCrack2 = 0.20f;
                    break;
                case 3:
                    wallCrack3 = 0.20f;
                    break;
                case 4:
                    wallCrack4 = 0.20f;
                    break;
                case 5:
                    wallCrack5 = 0.20f;
                    break;
                case 6:
                    wallCrack6 = 0.20f;
                    break;
            }

            check80 = true;

        }

        if (healthScript.cur_health < 300 && healthScript.cur_health > 200 && check60 == false)
        {
            rend.material.SetColor(materialColor, new Color(3.0321f, 3.245283f, 0, 2));
            switch (wallIndex)
            {
                case 1:
                    wallCrack1 = 0.40f;
                    break;
                case 2:
                    wallCrack2 = 0.40f;
                    break;
                case 3:
                    wallCrack3 = 0.40f;
                    break;
                case 4:
                    wallCrack4 = 0.40f;
                    break;
                case 5:
                    wallCrack5 = 0.40f;
                    break;
                case 6:
                    wallCrack6 = 0.40f;
                    break;
            }
            check60 = true;
        }

        if (healthScript.cur_health < 200 && healthScript.cur_health > 100 && check40 == false)
        {
            rend.material.SetColor(materialColor, new Color(4.332708f, 1.249614f, 0, 2));
            switch (wallIndex)
            {
                case 1:
                    wallCrack1 = 0.60f;
                    break;
                case 2:
                    wallCrack2 = 0.60f;
                    break;
                case 3:
                    wallCrack3 = 0.60f;
                    break;
                case 4:
                    wallCrack4 = 0.60f;
                    break;
                case 5:
                    wallCrack5 = 0.60f;
                    break;
                case 6:
                    wallCrack6 = 0.60f;
                    break;
            }
            check40 = true;
        }

        if (healthScript.cur_health < 100 && check20 == false)
        {
            rend.material.SetColor(materialColor, new Color(2.216312f, 0.0090094f, 0, 1.565086f));
            switch (wallIndex)
            {
                case 1:
                    wallCrack1 = 0.80f;
                    break;
                case 2:
                    wallCrack2 = 0.80f;
                    break;
                case 3:
                    wallCrack3 = 0.80f;
                    break;
                case 4:
                    wallCrack4 = 0.80f;
                    break;
                case 5:
                    wallCrack5 = 0.80f;
                    break;
                case 6:
                    wallCrack6 = 0.80f;
                    break;
            }
            check20 = true;
        }

        if (healthScript.cur_health <= 0 && check0 == false)
        {
            rend.material.SetColor(materialColor, new Color(2.216312f, 0.0090094f, 0, 1.565086f));
            switch (wallIndex)
            {
                case 1:
                    wallCrack1 = 0;
                    break;
                case 2:
                    wallCrack2 = 0;
                    break;
                case 3:
                    wallCrack3 = 0;
                    break;
                case 4:
                    wallCrack4 = 0;
                    break;
                case 5:
                    wallCrack5 = 0;
                    break;
                case 6:
                    wallCrack6 = 0;
                    break;
            }
            check0 = true;
        }

    }
}
