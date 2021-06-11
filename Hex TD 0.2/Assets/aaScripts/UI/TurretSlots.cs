using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlots : MonoBehaviour
{

    static bool standardTurretPlaced = false;
    static bool poisonTurretPlaced = false;
    static bool laserTurretPlaced = false;
    static bool minigunTurretPlaced = false;
    static bool aoeTurretPlaced = false;

    public static bool standardTurretSlot1;
    public static bool standardTurretSlot2;
    public static bool standardTurretSlot3;
    public static bool standardTurretSlot4;
    public static bool standardTurretSlot5;

    public static bool poisonTurretSlot1;
    public static bool poisonTurretSlot2;
    public static bool poisonTurretSlot3;
    public static bool poisonTurretSlot4;
    public static bool poisonTurretSlot5;

    public static bool laserTurretSlot1;
    public static bool laserTurretSlot2;
    public static bool laserTurretSlot3;
    public static bool laserTurretSlot4;
    public static bool laserTurretSlot5;

    public static bool minigunTurretSlot1;
    public static bool minigunTurretSlot2;
    public static bool minigunTurretSlot3;
    public static bool minigunTurretSlot4;
    public static bool minigunTurretSlot5;

    public static bool aoeTurretSlot1;
    public static bool aoeTurretSlot2;
    public static bool aoeTurretSlot3;
    public static bool aoeTurretSlot4;
    public static bool aoeTurretSlot5;


    public void UpdateSlots()
    {

        standardTurretSlot1 = false;
        standardTurretSlot2 = false;
        standardTurretSlot3 = false;
        standardTurretSlot4 = false;
        standardTurretSlot5 = false;

        poisonTurretSlot1 = false;
        poisonTurretSlot2 = false;
        poisonTurretSlot3 = false;
        poisonTurretSlot4 = false;
        poisonTurretSlot5 = false;

        laserTurretSlot1 = false;
        laserTurretSlot2 = false;
        laserTurretSlot3 = false;
        laserTurretSlot4 = false;
        laserTurretSlot5 = false;

        minigunTurretSlot1 = false;
        minigunTurretSlot2 = false;
        minigunTurretSlot3 = false;
        minigunTurretSlot4 = false;
        minigunTurretSlot5 = false;

        aoeTurretSlot1 = false;
        aoeTurretSlot2 = false;
        aoeTurretSlot3 = false;
        aoeTurretSlot4 = false;
        aoeTurretSlot5 = false;


        standardTurretPlaced = false;
        poisonTurretPlaced = false;
        laserTurretPlaced = false;
        minigunTurretPlaced = false;
        aoeTurretPlaced = false;

        //slot 1
        if (standardTurretPlaced == false && LoadoutMenu.standardTurretSelected == true)
        {
            standardTurretSlot1 = true;
            standardTurretPlaced = true;
            Debug.Log("Slot 5: standard turret selected");
        }
        else if (poisonTurretPlaced == false && LoadoutMenu.poisonTurretSelected == true)
        {
            poisonTurretSlot1 = true;
            poisonTurretPlaced = true;
            Debug.Log("Slot 5: Poison turret selected");
        }
        else if (laserTurretPlaced == false && LoadoutMenu.laserTurretSelected == true)
        {
            laserTurretSlot1 = true;
            laserTurretPlaced = true;
            Debug.Log("Slot 5: Laser turret selected");
        }
        else if (minigunTurretPlaced == false && LoadoutMenu.minigunTurretSelected == true)
        {
            minigunTurretSlot1 = true;
            minigunTurretPlaced = true;
            Debug.Log("Slot 5: Minigun turret selected");
        }
        else if (aoeTurretPlaced == false && LoadoutMenu.aoeTurretSelected == true)
        {
            aoeTurretSlot1 = true;
            aoeTurretPlaced = true;
            Debug.Log("Slot 5: AOE turret selected");
        }

        //slot 2
        if (standardTurretPlaced == false && LoadoutMenu.standardTurretSelected == true)
        {
            standardTurretSlot2 = true;
            standardTurretPlaced = true;
            Debug.Log("Slot 4: standard turret selected");
        }
        else if (poisonTurretPlaced == false && LoadoutMenu.poisonTurretSelected == true)
        {
            poisonTurretSlot2 = true;
            poisonTurretPlaced = true;
            Debug.Log("Slot 4: Poison turret selected");
        }
        else if (laserTurretPlaced == false && LoadoutMenu.laserTurretSelected == true)
        {
            laserTurretSlot2 = true;
            laserTurretPlaced = true;
            Debug.Log("Slot 4: Laser turret selected");
        }
        else if (minigunTurretPlaced == false && LoadoutMenu.minigunTurretSelected == true)
        {
            minigunTurretSlot2 = true;
            minigunTurretPlaced = true;
            Debug.Log("Slot 4: Minigun turret selected");
        }
        else if (aoeTurretPlaced == false && LoadoutMenu.aoeTurretSelected == true)
        {
            aoeTurretSlot2 = true;
            aoeTurretPlaced = true;
            Debug.Log("Slot 4: AOE turret selected");
        }

        //slot3
        if (standardTurretPlaced == false && LoadoutMenu.standardTurretSelected == true)
        {
            standardTurretSlot3 = true;
            standardTurretPlaced = true;
            Debug.Log("Slot 3: standard turret selected");
        }
        else if (poisonTurretPlaced == false && LoadoutMenu.poisonTurretSelected == true)
        {
            poisonTurretSlot3 = true;
            poisonTurretPlaced = true;
            Debug.Log("Slot 3: Poison turret selected");
        }
        else if (laserTurretPlaced == false && LoadoutMenu.laserTurretSelected == true)
        {
            laserTurretSlot3 = true;
            laserTurretPlaced = true;
            Debug.Log("Slot 3: Laser turret selected");
        }
        else if (minigunTurretPlaced == false && LoadoutMenu.minigunTurretSelected == true)
        {
            minigunTurretSlot3 = true;
            minigunTurretPlaced = true;
            Debug.Log("Slot 3: Minigun turret selected");
        }
        else if (aoeTurretPlaced == false && LoadoutMenu.aoeTurretSelected == true)
        {
            aoeTurretSlot3 = true;
            aoeTurretPlaced = true;
            Debug.Log("Slot 3: AOE turret selected");
        }

        //slot4
        if (standardTurretPlaced == false && LoadoutMenu.standardTurretSelected == true)
        {
            standardTurretSlot4 = true;
            standardTurretPlaced = true;
            Debug.Log("Slot 2: standard turret selected");
        }
        else if (poisonTurretPlaced == false && LoadoutMenu.poisonTurretSelected == true)
        {
            poisonTurretSlot4 = true;
            poisonTurretPlaced = true;
            Debug.Log("Slot 2: Poison turret selected");
        }
        else if (laserTurretPlaced == false && LoadoutMenu.laserTurretSelected == true)
        {
            laserTurretSlot4 = true;
            laserTurretPlaced = true;
            Debug.Log("Slot 2: Laser turret selected");
        }
        else if (minigunTurretPlaced == false && LoadoutMenu.minigunTurretSelected == true)
        {
            minigunTurretSlot4 = true;
            minigunTurretPlaced = true;
            Debug.Log("Slot 2: Minigun turret selected");
        }
        else if (aoeTurretPlaced == false && LoadoutMenu.aoeTurretSelected == true)
        {
            aoeTurretSlot4 = true;
            aoeTurretPlaced = true;
            Debug.Log("Slot 2: AOE turret selected");
        }

        //slot5
        if (standardTurretPlaced == false && LoadoutMenu.standardTurretSelected == true)
        {
            standardTurretSlot5 = true;
            standardTurretPlaced = true;
            Debug.Log("Slot 1: standard turret selected");
        }
        else if (poisonTurretPlaced == false && LoadoutMenu.poisonTurretSelected == true)
        {
            poisonTurretSlot5 = true;
            poisonTurretPlaced = true;
            Debug.Log("Slot 1: Poison turret selected");
        }
        else if (laserTurretPlaced == false && LoadoutMenu.laserTurretSelected == true)
        {
            laserTurretSlot5 = true;
            laserTurretPlaced = true;
            Debug.Log("Slot 1: Laser turret selected");
        }
        else if (minigunTurretPlaced == false && LoadoutMenu.minigunTurretSelected == true)
        {
            minigunTurretSlot5 = true;
            minigunTurretPlaced = true;
            Debug.Log("Slot 1: Minigun turret selected");
        }
        else if (aoeTurretPlaced == false && LoadoutMenu.aoeTurretSelected == true)
        {
            aoeTurretSlot5 = true;
            aoeTurretPlaced = true;
            Debug.Log("Slot 1: AOE turret selected");
        }


        LoadoutMenu.aoeTurretSelected = false;
        LoadoutMenu.standardTurretSelected = false;
        LoadoutMenu.poisonTurretSelected = false;
        LoadoutMenu.laserTurretSelected = false;
        LoadoutMenu.minigunTurretSelected = false;

        LoadoutMenu.turretQuantity = LoadoutMenu.turretquanitybase;
        LoadoutMenu.turretsSelected = 0;
        LoadoutMenu.previousTurretsSelected = 0;
    }
}
