using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System.Linq.Expressions;

public class Node : MonoBehaviour
{
    private AudioSource dropAudio;

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector] //Allows to put default turrets in any node
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprintShop turretBlueprintShop;


    [HideInInspector]
    public Turret turretStats;

    //public TurretBlueprintStats turretBlueprintStats;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    public int nodeSector;

    int range;
    float fireRate;

    BuildManager buildManager;

    public GameObject child;
    public GameObject child2;

    private float radius = 1.0f;
    private Color originalColor;
    private Color originalColorE;

    static readonly int materialEmissionColor = Shader.PropertyToID("_EmissionColor");

    void Start()
    {
        dropAudio = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!Tutorial.hexTutorialDone)
            return;

        if (turret != null)
        {
            SendStatsToUI(turret);
            buildManager.SelectNode(this); //this prevents from building where theres a turret
            this.tag = "ActiveNode";



            // Turret.healthStatic.ToString();


            // this.range = turretStats.range;
            // this.fireRate = turretStats.fireRate;
            return;
        }
}
    public void RemoveRange()
    {
        child.transform.localScale = (new Vector3(0, 0, 0));
        child2.transform.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, originalColorE);
        child2.transform.GetComponent<MeshRenderer>().material.color = originalColor;
    }



    void BuildTurret(TurretBlueprintShop blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            return; //add not enough money feature display
        }

        PlayerStats.money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.pref, GetBuildPosition(), Quaternion.identity);

        Tutorial.tutorialNodes = true;
    
        turret = _turret;
        Turret Sturret = turret.transform.GetComponent<Turret>();
        Sturret.NodeSectionTargetingShit(nodeSector); //sends nodeSector value to the void function in the turret script

        turretBlueprintShop = blueprint;

    }

    public void SendStatsToUI(GameObject turretS)
    {
        Turret currentTurret = turretS.GetComponent<Turret>();
        child = turretS.transform.GetChild(0).gameObject;
        child2 = turretS.transform.GetChild(1).gameObject;
        originalColorE = child2.transform.GetComponent<MeshRenderer>().material.GetColor(materialEmissionColor);
        child2.transform.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(1f, 1f, 1f));
        originalColor = child2.transform.GetComponent<MeshRenderer>().material.color;
        child2.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
        radius = currentTurret.range;
        child.transform.localScale = (new Vector3(radius * 2, radius * 2, radius * 2));
        NodeUI.fireRateValue = currentTurret.fireRate;
        NodeUI.rangeValue = currentTurret.range;

        if (!currentTurret.useLaser)
        {
            NodeUI.damageValue = currentTurret.bulletDamage;
        }
        else
        {
            NodeUI.damageValue = currentTurret.laserDamage;
        }
    }

    public void UpgradeTurret(GameObject nodeUI)
    {
        if (PlayerStats.money < turretBlueprintShop.upgradeCost)
        {
            return;
        }

        PlayerStats.money -= turretBlueprintShop.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprintShop.upgradedPref, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        Turret Sturret = turret.transform.GetComponent<Turret>();
        Sturret.NodeSectionTargetingShit(nodeSector);
        SendStatsToUI(turret);
        nodeUI.GetComponent<NodeUI>().Stats();

        // GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // Destroy(effect, 2f);
        //display turret upgraded

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprintShop.GetSellAmount();
        //put sell effect here
        Destroy(turret);
        turretBlueprintShop = null;

    }

    public void SellUpgradedTurret()
    {
        PlayerStats.money += turretBlueprintShop.GetUpgradedSellAmount();
        //put sell effect here
        Destroy(turret);
        isUpgraded = false;
        turretBlueprintShop = null;

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && UnitGhost.dragGhost == true && rend.CompareTag("Node"))
        {
            if (!buildManager.CanBuild)
                return;

            dropAudio.PlayOneShot(dropAudio.clip);
            BuildTurret(buildManager.GetTurretToBuild());

            if (buildManager.HasMoney)
            this.tag = "ActiveNode";

        }
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (this.CompareTag("ActiveNode"))
        {
            UnitGhost.RedGhost();
            return;
        }

        if (!buildManager.CanBuild)
            return;

        if (!UnitGhost.dragGhost)
            return;

        if (buildManager.HasMoney && turret == null)
        {
            UnitGhost.NormalGhost();
            rend.material.color = hoverColor;
            dropAudio.pitch = 1f;
            dropAudio.volume = 0.6f;
        }
        else
        {
            if (turret == null)
            {
                UnitGhost.RedGhost();
                rend.material.color = notEnoughMoneyColor;
                dropAudio.pitch = 0.5f;
                dropAudio.volume = 0.9f;
            }

        }

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
