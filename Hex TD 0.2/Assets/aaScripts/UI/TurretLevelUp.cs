using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretLevelUp : MonoBehaviour
{
    int standardLevelUpCost = 10;
    int poisonLevelUpCost = 11;
    int laserLevelUpCost = 12;
    int minigunLevelUpCost = 13;
    int aoeLevelUpCost = 14;

    public Text upgradeCurrencyText;

    public Text standardTurretLevelText;
    public Text poisonTurretLevelText;
    public Text laserTurretLevelText;
    public Text minigunTurretLevelText;
    public Text aoeTurretLevelText;

    public Text standardLevelUpCostText;
    public Text poisonLevelUpCostText;
    public Text laserLevelUpCostText;
    public Text minigunLevelUpCostText;
    public Text aoeLevelUpCostText;

    public Button standardButton;
    public Button poisonButton;
    public Button laserButton;
    public Button minigunButton;
    public Button aoeButton;

    //Standard Turret Values
    public Text StandardText_Damage;
    public Text StandardText_RateOfFire;
    public Text StandardText_Range;

    private float StandardValue_Damage = 15;
    private float StandardValue_RateOfFire = 1;
    private float StandardValue_Range = 10;

    //Poison Turret Values
    public Text PoisonText_Damage;
    public Text PoisonText_RateOfFire;
    public Text PoisonText_Range;

    private float PoisonValue_Damage = 10;
    private float PoisonValue_RateOfFire = 1;
    private float PoisonValue_Range = 10;
    //Laser Turret Values
    public Text LaserText_Damage;
    public Text LaserText_RateOfFire;
    public Text LaserText_Range;

    private float LaserValue_Damage = 30;
    private float LaserValue_RateOfFire = 1;
    private float LaserValue_Range = 10;
    //Minigun Turret Values
    public Text MinigunText_Damage;
    public Text MinigunText_RateOfFire;
    public Text MinigunText_Range;

    private float MinigunValue_Damage = 2;
    private float MinigunValue_RateOfFire = 1;
    private float MinigunValue_Range = 10;
    //AOE Turret Values
    public Text AOEText_Damage;
    public Text AOEText_RateOfFire;
    public Text AOEText_Range;

    private float AOEValue_Damage = 5;
    private float AOEValue_RateOfFire = 1;
    private float AOEValue_Range = 10;


    bool[] standardUpgradeLevel = { true, false, false, false, false, false, false, false, false, false };
    bool[] poisonUpgradeLevel = { true, false, false, false, false, false, false, false, false, false };
    bool[] laserUpgradeLevel = { true, false, false, false, false, false, false, false, false, false };
    bool[] minigunUpgradeLevel = { true, false, false, false, false, false, false, false, false, false };
    bool[] aoeUpgradeLevel = { true, false, false, false, false, false, false, false, false, false };

    int standardPreviousUpgradeLevel = -1;
    int poisonPreviousUpgradeLevel = -1;
    int laserPreviousUpgradeLevel = -1;
    int minigunPreviousUpgradeLevel = -1;
    int aoePreviousUpgradeLevel = -1;

    int standardUpgradeLevelNumber = 0;
    int poisonUpgradeLevelNumber = 0;
    int laserUpgradeLevelNumber = 0;
    int minigunUpgradeLevelNumber = 0;
    int aoeUpgradeLevelNumber = 0;

    public static float standardTurretMultiplier = 1;
    public static float poisonTurretMultiplier = 1;
    public static float laserTurretMultiplier = 1;
    public static float minigunTurretMultiplier = 1;
    public static float aoeTurretMultiplier = 1;

    bool startupUpdate = false;

    public static int upgradeCurrency = 50000;


    private void Start()
    {
        //Standard Turret Values
        standardTurretLevelText.text = "LVL. " + (standardUpgradeLevelNumber + 1);
        StandardText_Damage.text = (StandardValue_Damage * standardTurretMultiplier).ToString("F0");

        //Poison Turret Values
        poisonTurretLevelText.text = "LVL. " + (standardUpgradeLevelNumber + 1);
        PoisonText_Damage.text = (PoisonValue_Damage * poisonTurretMultiplier).ToString("F0");

        //Laser Turret Values
        laserTurretLevelText.text = "LVL. " + (standardUpgradeLevelNumber + 1);
        LaserText_Damage.text = (LaserValue_Damage * laserTurretMultiplier).ToString("F0");

        //Minigun Turret Values
        minigunTurretLevelText.text = "LVL. " + (standardUpgradeLevelNumber + 1);
        MinigunText_Damage.text = (MinigunValue_Damage * minigunTurretMultiplier).ToString("F0");

        //AOE Turret Values
        aoeTurretLevelText.text = "LVL. " + (standardUpgradeLevelNumber + 1);
        AOEText_Damage.text = (AOEValue_Damage * aoeTurretMultiplier).ToString("F0");

    }
    public void LevelUpStandard()
    {
        if (upgradeCurrency >= standardLevelUpCost && standardPreviousUpgradeLevel < standardUpgradeLevelNumber
        && (upgradeCurrency - standardLevelUpCost) >= 0 && standardUpgradeLevelNumber < 9)
        {
            standardUpgradeLevel[standardUpgradeLevelNumber] = true;
            upgradeCurrency -= standardLevelUpCost;
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            standardLevelUpCost += standardLevelUpCost;
            standardLevelUpCostText.text = "Level Up\n$ " + standardLevelUpCost;
            standardPreviousUpgradeLevel = standardUpgradeLevelNumber;
            standardUpgradeLevelNumber++;
            standardTurretMultiplier *= 1.2f;
            StandardText_Damage.text = (StandardValue_Damage * standardTurretMultiplier).ToString("F0");
            standardTurretLevelText.text = "LVL. " + (standardUpgradeLevelNumber + 1);
        }
        if (standardUpgradeLevelNumber == 9)
        {
            standardLevelUpCostText.text = "Max level";
            standardButton.interactable = false;
        }
            

    }

    public void LevelUpPoison()
    {
        if (upgradeCurrency >= poisonLevelUpCost && poisonPreviousUpgradeLevel < poisonUpgradeLevelNumber
        && (upgradeCurrency - poisonLevelUpCost) >= 0 && poisonUpgradeLevelNumber < 9)
        {
            poisonUpgradeLevel[poisonUpgradeLevelNumber] = true;
            upgradeCurrency -= poisonLevelUpCost;
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            poisonLevelUpCost += poisonLevelUpCost;
            poisonLevelUpCostText.text = "Level Up\n$ " + poisonLevelUpCost;
            poisonPreviousUpgradeLevel = poisonUpgradeLevelNumber;
            poisonUpgradeLevelNumber++;
            poisonTurretMultiplier *= 1.2f;
            PoisonText_Damage.text = (PoisonValue_Damage * poisonTurretMultiplier).ToString("F0");
            poisonTurretLevelText.text = "LVL. " + (poisonUpgradeLevelNumber + 1);
        }
        if (poisonUpgradeLevelNumber == 9)
        {
            poisonLevelUpCostText.text = "Max level";
            poisonButton.interactable = false;
        }
            
    }

    public void LevelUpLaser()
    {
        if (upgradeCurrency >= laserLevelUpCost && laserPreviousUpgradeLevel < laserUpgradeLevelNumber
        && (upgradeCurrency - laserLevelUpCost) >= 0 && laserUpgradeLevelNumber < 9)
        {
            laserUpgradeLevel[laserUpgradeLevelNumber] = true;
            upgradeCurrency -= laserLevelUpCost;
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            laserLevelUpCost += laserLevelUpCost;
            laserLevelUpCostText.text = "Level Up\n$ " + laserLevelUpCost;
            laserPreviousUpgradeLevel = laserUpgradeLevelNumber;
            laserUpgradeLevelNumber++;
            laserTurretMultiplier *= 1.2f;
            LaserText_Damage.text = (LaserValue_Damage * laserTurretMultiplier).ToString("F0");
            laserTurretLevelText.text = "LVL. " + (laserUpgradeLevelNumber + 1);
        }
        if (laserUpgradeLevelNumber == 9)
        {
            laserLevelUpCostText.text = "Max level";
            laserButton.interactable = false;
        }
            
    }

    public void LevelUpMinigun()
    {
        if (upgradeCurrency >= minigunLevelUpCost && minigunPreviousUpgradeLevel < minigunUpgradeLevelNumber
        && (upgradeCurrency - minigunLevelUpCost) >= 0 && minigunUpgradeLevelNumber < 9)
        {
            minigunUpgradeLevel[minigunUpgradeLevelNumber] = true;
            upgradeCurrency -= minigunLevelUpCost;
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            minigunLevelUpCost += minigunLevelUpCost;
            minigunLevelUpCostText.text = "Level Up\n$ " + minigunLevelUpCost;
            minigunPreviousUpgradeLevel = minigunUpgradeLevelNumber;
            minigunUpgradeLevelNumber++;
            minigunTurretMultiplier *= 1.2f;
            MinigunText_Damage.text = (MinigunValue_Damage * minigunTurretMultiplier).ToString("F0");
            minigunTurretLevelText.text = "LVL. " + (minigunUpgradeLevelNumber + 1);
        }
        if (minigunUpgradeLevelNumber == 9)
        { 
            minigunLevelUpCostText.text = "Max level";
            minigunButton.interactable = false;
        }
    }
    

    public void LevelUpAoe()
    {
        if (upgradeCurrency >= aoeLevelUpCost && aoePreviousUpgradeLevel < aoeUpgradeLevelNumber
        && (upgradeCurrency - aoeLevelUpCost) >= 0 && aoeUpgradeLevelNumber < 9)
        {
            aoeUpgradeLevel[aoeUpgradeLevelNumber] = true;
            upgradeCurrency -= aoeLevelUpCost;
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            aoeLevelUpCost += aoeLevelUpCost;
            aoeLevelUpCostText.text = "Level Up\n$ " + aoeLevelUpCost;
            aoePreviousUpgradeLevel = aoeUpgradeLevelNumber;
            aoeUpgradeLevelNumber++;
            aoeTurretMultiplier *= 1.2f;
            AOEText_Damage.text = (AOEValue_Damage * aoeTurretMultiplier).ToString("F0");
            aoeTurretLevelText.text = "LVL. " + (aoeUpgradeLevelNumber + 1);
        }
        if (aoeUpgradeLevelNumber == 9)
        {
            aoeLevelUpCostText.text = "Max level";
            aoeButton.interactable = false;
        }
    }

    private void Update()
    {
        if (startupUpdate == false)
        {
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            standardLevelUpCostText.text = "Level Up\n$ " + standardLevelUpCost;
            poisonLevelUpCostText.text = "Level Up\n$ " + poisonLevelUpCost;
            laserLevelUpCostText.text = "Level Up\n$ " + laserLevelUpCost;
            minigunLevelUpCostText.text = "Level Up\n$ " + minigunLevelUpCost;
            aoeLevelUpCostText.text = "Level Up\n$ " + aoeLevelUpCost;

            startupUpdate = true;
        }
    }
}
