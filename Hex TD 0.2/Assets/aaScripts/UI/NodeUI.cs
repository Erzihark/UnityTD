using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
   // public GameObject disableUIButton;
   // private bool checkUI = false;

    public Text upgradeCost;
    public Text fireRate;
    public Text damage;
    public Text range;
    public Text sellAmmount;

    public static float fireRateValue;
    public static float damageValue;
    public static int rangeValue;

    public TurretBlueprintShop standardTurret;
    public TurretBlueprintShop missileLauncher;
    public TurretBlueprintShop laserTurret;

    private Node target;
    public Button upgradeButton;

    public bool tutorialCounter = false;
    
    public void Stats()
    {
        damageValue= Mathf.Round(damageValue * 10.0f) * 0.1f;

        fireRate.text = fireRateValue.ToString();
        damage.text = damageValue.ToString();
        range.text = rangeValue.ToString();
    }


    public void SetTarget(Node _target)
    {
        target = _target;

        Stats();

        //fireRate.text = target.turretStats.fireRate.ToString();

        sellAmmount.text = "$" + target.turretBlueprintShop.GetUpgradedSellAmount();

        //transform.position = target.GetBuildPosition(); //this uses the node location with the offset
        // we made before

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprintShop.upgradeCost;
            upgradeButton.interactable = true;
            
            
            sellAmmount.text = "$" + target.turretBlueprintShop.GetSellAmount();
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }
        ui.SetActive(true);


        //checkUI = true;
    }

    public void Hide()
    {
        ui.SetActive(false);

    }


    public void Upgrade()
    {   
        target.UpgradeTurret(this.gameObject);
        tutorialCounter = true;
    }

    public void Sell()
    {
        if (target.isUpgraded)
        {
            target.SellUpgradedTurret();
            target.tag = "Node";
            BuildManager.instance.DeselectNode();
        }
        else
        {
            target.SellTurret();
            target.tag = "Node";
            BuildManager.instance.DeselectNode(); //deselects node after selling turret
        }
        Hide();
        tutorialCounter = true;
    }
    public void Update()
    {
        if (ui == enabled)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0))
            {
               
                    if (Physics.Raycast(ray, out Hit) && Hit.collider.tag != "ActiveNode" && Hit.collider.tag != "UIButtons")
                    {
                         BuildManager.instance.DeselectNode();
                         
                    }

                
            }
        }

    }
    

    }