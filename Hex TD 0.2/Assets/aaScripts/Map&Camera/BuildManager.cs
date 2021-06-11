using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    

    public static BuildManager instance; //stores a reference to itself to limit instances to 1

    public static bool tutorialGhost = false;


    private void Awake()
    {
        if (instance!= null)
        {
           
            return;
        }
        
        instance = this;
    }
    
    public GameObject buildEffect;

    private TurretBlueprintShop turretToBuild;

    private Node selectedNode;

    public NodeUI nodeUI;

    public GameObject Ghost;
    public static bool GhostActive = false;

    //This function is called a property cus it only allows to get a return value
    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public bool HasMoney
    {
        get
        {
            return PlayerStats.money >= turretToBuild.cost;
        }
    }


    //the following lines till line 71 is so that nodes and turrets cant be selected at the same time  
    public void SelectNode (Node node)
    {

        if(selectedNode != node)
        {
            DeselectNode();
        }

        selectedNode = node;

        turretToBuild = null;
        nodeUI.SetTarget(node);



    }

    //Deactivates UI when u click the selected node
    public void DeselectNode()
    {
        if (selectedNode != null)
        {
             WaveSpawnerTopRight_Main.tutorialOn = false;
             selectedNode.RemoveRange();
             selectedNode = null;
             nodeUI.Hide();
        }
    }
    public void SelectTurretToBuild(TurretBlueprintShop turret)
    {
        if (tutorialGhost)
            return;

        if (GhostActive)
        {
            Destroy(Ghost);
        }

        turretToBuild = turret;
        Ghost = Instantiate(turretToBuild.pref.GetComponent<Turret>().turretGhost, new Vector3(-0.02f,0.85f,0f), Quaternion.identity) as GameObject;

        if (Tutorial.tutorialCounter == false)
        {
            Tutorial.tutorialCounter = true;
        } 

        Ghost.AddComponent<UnitGhost>();
        Ghost.AddComponent<TurretRange>();
        GhostActive = true;
        DeselectNode();
    }

    public TurretBlueprintShop GetTurretToBuild()
    {
        return turretToBuild;
    }
}
