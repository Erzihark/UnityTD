using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprintShop standardTurret;
    public TurretBlueprintShop missileLauncher;
    public TurretBlueprintShop laserTurret;
    public TurretBlueprintShop minigunTurret;
    public TurretBlueprintShop aoeTurret;

    public static bool turretBought = false;

    BuildManager buildManager;

    public GameObject[] turretsSlot1;
    public GameObject[] turretsSlot2;
    public GameObject[] turretsSlot3;
    public GameObject[] turretsSlot4;
    public GameObject[] turretsSlot5;

    private void Start()
    {
        buildManager = BuildManager.instance;
        
        //slot 1
        if (TurretSlots.standardTurretSlot1)
        {
            turretsSlot1[0].SetActive(true);
        }
        else if (TurretSlots.poisonTurretSlot1)
        {
            turretsSlot1[1].SetActive(true);
        }
        else if (TurretSlots.laserTurretSlot1)
        {
            turretsSlot1[2].SetActive(true);
        }
        else if (TurretSlots.minigunTurretSlot1)
        {
            turretsSlot1[3].SetActive(true);
        }
        else if (TurretSlots.aoeTurretSlot1)
        {
            turretsSlot1[4].SetActive(true);
        }
        else
        {
            turretsSlot1[0].SetActive(true);
        }

        //slot 2
        if (TurretSlots.standardTurretSlot2)
        {
            turretsSlot2[0].SetActive(true);
        }
        else if (TurretSlots.poisonTurretSlot2)
        {
            turretsSlot2[1].SetActive(true);
        }
        else if (TurretSlots.laserTurretSlot2)
        {
            turretsSlot2[2].SetActive(true);
        }
        else if (TurretSlots.minigunTurretSlot2)
        {
            turretsSlot2[3].SetActive(true);
        }
        else if (TurretSlots.aoeTurretSlot2)
        {
            turretsSlot2[4].SetActive(true);
        }
        else
        {
            turretsSlot2[1].SetActive(true);
        }

        //slot 3
        if (TurretSlots.standardTurretSlot3)
        {
            turretsSlot3[0].SetActive(true);
        }
        else if (TurretSlots.poisonTurretSlot3)
        {
            turretsSlot3[1].SetActive(true);
        }
        else if (TurretSlots.laserTurretSlot3)
        {
            turretsSlot3[2].SetActive(true);
        }
        else if (TurretSlots.minigunTurretSlot3)
        {
            turretsSlot3[3].SetActive(true);
        }
        else if (TurretSlots.aoeTurretSlot3)
        {
            turretsSlot3[4].SetActive(true);
        }
        else
        {
            turretsSlot3[2].SetActive(true);
        }

        //slot 4
        if (TurretSlots.standardTurretSlot4)
        {
            turretsSlot4[0].SetActive(true);
        }
        else if (TurretSlots.poisonTurretSlot4)
        {
            turretsSlot4[1].SetActive(true);
        }
        else if (TurretSlots.laserTurretSlot4)
        {
            turretsSlot4[2].SetActive(true);
        }
        else if (TurretSlots.minigunTurretSlot4)
        {
            turretsSlot4[3].SetActive(true);
        }
        else if (TurretSlots.aoeTurretSlot4)
        {
            turretsSlot4[4].SetActive(true);
        }

        //slot 5
        if (TurretSlots.standardTurretSlot5)
        {
            turretsSlot5[0].SetActive(true);
        }
        else if (TurretSlots.poisonTurretSlot5)
        {
            turretsSlot5[1].SetActive(true);
        }
        else if (TurretSlots.laserTurretSlot5)
        {
            turretsSlot5[2].SetActive(true);
        }
        else if (TurretSlots.minigunTurretSlot5)
        {
            turretsSlot5[3].SetActive(true);
        }
        else if (TurretSlots.aoeTurretSlot5)
        {
            turretsSlot5[4].SetActive(true);
        }


    }

    public void SelectStandardTurret ()
    {
        buildManager.SelectTurretToBuild(standardTurret);
        turretBought = true;
    }

    public void SelectMissileLauncher ()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
        turretBought = true;
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
        turretBought = true;
    }

    public void SelectMinigunTurret()
    {
        buildManager.SelectTurretToBuild(minigunTurret);
        turretBought = true;
    }

    public void SelectaoeTurret()
    {
        buildManager.SelectTurretToBuild(aoeTurret);
        turretBought = true;
    }
}
