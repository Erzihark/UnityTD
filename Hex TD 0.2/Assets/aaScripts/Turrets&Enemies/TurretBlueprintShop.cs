using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //makes the variables in this script visible in inspector
//needed so that data can be input from inspector in the shop script
public class TurretBlueprintShop
{
    public GameObject pref;
    public int cost;

    public GameObject upgradedPref;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }

    public int GetUpgradedSellAmount()
    {
        return upgradeCost / 2;
    }
}
