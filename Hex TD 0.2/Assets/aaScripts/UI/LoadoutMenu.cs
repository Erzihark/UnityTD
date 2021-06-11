using UnityEngine;
using UnityEngine.UI;

public class LoadoutMenu : MonoBehaviour
{

    public static int turretquanitybase = 3;
    public static int turretQuantity;
    public static int turretsSelected = 0;
    public static int previousTurretsSelected = 0;

    public static bool standardTurretSelected = false;
    public static bool poisonTurretSelected = false;
    public static bool laserTurretSelected = false;
    public static bool minigunTurretSelected = false;
    public static bool aoeTurretSelected = false;

    private bool startupUpdate = true;
     
    public Text numberTurretsSelectedText;

    public static LevelEndMenu levelProgress;


    private void Start()
    {
        turretQuantity = turretquanitybase;
    }
    public void selectTurrets()
    {
        if (turretsSelected < (turretQuantity + turretsSelected))
        {
            turretsSelected++;
            turretQuantity--;
        }

    }

   public void deselectTurrets()
    {
        if (turretsSelected > 0)
        {
            turretsSelected--;
            turretQuantity++;
        }

    }

    private void Update()
    {
        if (startupUpdate == true || turretsSelected != previousTurretsSelected)
        {
            numberTurretsSelectedText.text = turretQuantity.ToString();
            previousTurretsSelected = turretsSelected;
            startupUpdate = false;
        }
    }

    public void ApplyPressed()
    {
        numberTurretsSelectedText.text = turretQuantity.ToString();
    }

    public void StandardTurretSelected()
    {
        standardTurretSelected = true;
    }
    public void PoisonTurretSelected()
    {
        poisonTurretSelected = true;
    }
    public void LaserTurretSelected()
    {
        laserTurretSelected = true;
    }
    public void MinigunTurretSelected()
    {
        minigunTurretSelected = true;
    }
    public void AoETurretSelected()
    {
        aoeTurretSelected = true;
    }


    public void StandardTurretDeselected()
    {
        standardTurretSelected = false;
    }
    public void PoisonTurretDeselected()
    {
        poisonTurretSelected = false;
    }
    public void LaserTurretDeselected()
    {
        laserTurretSelected = false;
    }
    public void MinigunTurretDeselected()
    {
        minigunTurretSelected = false;
    }
    public void AoETurretDeselected()
    {
        aoeTurretSelected = false;
    }



}