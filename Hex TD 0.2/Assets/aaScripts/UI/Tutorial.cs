using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public NodeUI nodeUI;

    public GameObject selectTurretTooltip;
    public GameObject skipTutorialButton;
    public GameObject dragAndDropTooltip;
    public GameObject upgradeTooltip;
    public GameObject waveStarterTooltip;

    public GameObject tooltipCanvas;

    public Text dragAndDropText;
    public static bool tutorialNodes;
    public static bool hexTutorialDone = false;

    public static bool skipTutorial = false;
    public static bool tutorialCounter = false;
    private bool waveStarterTutorialDone = false;
    private bool upgradeTutorialDone = false;
    public static bool outerHexTutorial = false;

    private GameObject innerHex1;
    private GameObject innerHex2;
    private GameObject innerHex3;
    private GameObject innerHex4;

    private GameObject outerHex1;
    private GameObject outerHex2;

    static readonly int materialEmissionColor = Shader.PropertyToID("_EmissionColor");
    static readonly int materialMetallicColor = Shader.PropertyToID("_Metallic");

    static readonly int materialEmissionColor2 = Shader.PropertyToID("_EmissionColor");
    static readonly int materialMetallicColor2 = Shader.PropertyToID("_Metallic");


    private float innerHexTutorialTimer;
    private float outerHexTutorialTimer;
    private bool timerRunning;

    public static bool nextLevel = false;


    void Update()
    {
        if (nextLevel && selectTurretTooltip.activeSelf && skipTutorialButton.activeSelf)
        {
            tooltipCanvas.SetActive(false);
            selectTurretTooltip.SetActive(false);
            skipTutorialButton.SetActive(false);
            dragAndDropTooltip.SetActive(false);
            upgradeTooltip.SetActive(false);
            waveStarterTooltip.SetActive(false);
            WaveSpawnerTopRight_Main.tutorialOn = false;
            waveStarterTutorialDone = true;
            skipTutorial = true;
            BuildManager.tutorialGhost = false;
            hexTutorialDone = true;
            nodeUI.tutorialCounter = true;
            return;
        }

        if (waveStarterTutorialDone || skipTutorial)
            return;


        if (Shop.turretBought == true)
        {
            selectTurretTooltip.SetActive(false);
            skipTutorialButton.SetActive(false);
        }

        if (!WaveSpawnerTopRight_Main.tutorialOn)
        {
            waveStarterTooltip.SetActive(true);

            if (WaveSpawnerTopRight_Main.startFirstWave > 0)
            {
                waveStarterTooltip.SetActive(false);
                waveStarterTutorialDone = true;
            }
        }
        if (upgradeTutorialDone)
        {
            return;
        }

        if (nodeUI.isActiveAndEnabled && hexTutorialDone)
        {
            dragAndDropTooltip.SetActive(false);
            upgradeTooltip.SetActive(true);
        } 
        else if (hexTutorialDone && upgradeTooltip.activeSelf)
        {
            upgradeTooltip.SetActive(false);
            upgradeTutorialDone = true;
        }

        if (hexTutorialDone)
        {
            return;
        }
            
        if (tutorialNodes)
        {
            innerHexTutorialTimer -= Time.deltaTime;
            outerHexTutorialTimer -= Time.deltaTime;

            if (innerHexTutorialTimer <= 0 && !outerHexTutorial)
            {
                innerHexTutorialTimer = 6f;
                dragAndDropText.text = "TURRETS PLACED HERE WILL ONLY ATTACK THIS LANE";
                GameObject.Find("TutorialPointer").transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                BuildManager.tutorialGhost = true;
            }

            if (innerHexTutorialTimer > 0)
            {
                outerHexTutorial = true;
            }

            if (outerHexTutorialTimer <= 0 && timerRunning == true)
            {
                GameObject[] hexes = GameObject.FindGameObjectsWithTag("Node");

                foreach (GameObject hex in hexes)
                {
                    hex.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor2, 0.3f);
                    hex.transform.localScale = new Vector3(1, 1, 0.5f);
                }

                outerHex1.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor2, new Color(0.1933962f, 0.1933962f, 0.1933962f));
                outerHex2.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor2, new Color(0.1933962f, 0.1933962f, 0.1933962f));

                outerHex1.GetComponent<MeshRenderer>().material.color = new Color(0, 0.517309f, 0.5660378f, 1);
                outerHex2.GetComponent<MeshRenderer>().material.color = new Color(0, 0.517309f, 0.5660378f, 1);

                GameObject.Find("TutorialPointer").SetActive(false);
                GameObject.Find("TutorialPointer2").SetActive(false);


                dragAndDropText.text = "CLICK A TURRET TO VIEW ITS STATS";

                BuildManager.tutorialGhost = false;
                hexTutorialDone = true;
                return;

            }

            if (outerHexTutorial && innerHexTutorialTimer <= 0 && outerHexTutorialTimer <= 0 && timerRunning == false)
            {

                Tutorial.outerHexTutorial = true;
                dragAndDropText.text = "TURRETS PLACED HERE WILL ATTACK BOTH LANES";
                GameObject.Find("TutorialPointer2").transform.localScale = new Vector3(0.5f, 0.3f, 0.3f);
                GameObject.Find("TutorialPointer").transform.localScale = new Vector3(0.5f, 0.3f, 0.3f);
                GameObject.Find("TutorialPointer").transform.localPosition = new Vector3(0.1157f, 0.3979f, 0f);

                outerHex1 = GameObject.Find("Hex Tile TopVertex1");
                outerHex2 = GameObject.Find("Hex Tile TopVertex2");

                GameObject[] hexes = GameObject.FindGameObjectsWithTag("Node");

                foreach (GameObject hex in hexes)
                {
                    hex.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor2, 1);
                    hex.transform.localScale = new Vector3(0, 0, 0);
                }

                outerHex1.transform.localScale = new Vector3(1, 1, 0.5f);
                outerHex2.transform.localScale = new Vector3(1, 1, 0.5f);

                outerHex1.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor2, 0.3f);
                outerHex2.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor2, 0.3f);

                outerHex1.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor2, new Color(1, 1, 1));
                outerHex2.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor2, new Color(1, 1, 1));

                outerHex1.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
                outerHex2.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);

                outerHexTutorialTimer = 6f;
                timerRunning = true;
            }
        }

        if (outerHexTutorial)
        {
            innerHex1.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(0.1698113f, 0.1698113f, 0.1698113f));
            innerHex2.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(0.1698113f, 0.1698113f, 0.1698113f));
            innerHex3.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(0.1698113f, 0.1698113f, 0.1698113f));
            innerHex4.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(0.1698113f, 0.1698113f, 0.1698113f));
        }

        if (tutorialCounter && !tutorialNodes && !outerHexTutorial)
        {
            dragAndDropTooltip.SetActive(true);
            innerHex1 = GameObject.Find("Hex Tile TopRight1");
            innerHex2 = GameObject.Find("Hex Tile TopRight2");
            innerHex3 = GameObject.Find("Hex Tile TopRight3");
            innerHex4 = GameObject.Find("Hex Tile TopRight4");

            GameObject[] hexes = GameObject.FindGameObjectsWithTag("Node");

            foreach (GameObject hex in hexes)
            {
                hex.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor, 1);
                hex.transform.localScale = new Vector3(0, 0, 0);
            }

            innerHex1.transform.localScale = new Vector3(1, 1, 0.5f);
            innerHex2.transform.localScale = new Vector3(1, 1, 0.5f);
            innerHex3.transform.localScale = new Vector3(1, 1, 0.5f);
            innerHex4.transform.localScale = new Vector3(1, 1, 0.5f);

            innerHex1.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor, 0.3f);
            innerHex2.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor, 0.3f);
            innerHex3.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor, 0.3f);
            innerHex4.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor, 0.3f);

            innerHex1.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(1, 1, 1));
            innerHex2.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(1, 1, 1));
            innerHex3.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(1, 1, 1));
            innerHex4.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(1, 1, 1));
        }
    }

        public void SkipTutorial()
        {
            skipTutorial = true;
            WaveSpawnerTopRight_Main.tutorialOn = false;
            upgradeTooltip.SetActive(false);
            dragAndDropTooltip.SetActive(false);
            waveStarterTooltip.SetActive(false);
            selectTurretTooltip.SetActive(false);
            BuildManager.tutorialGhost = false;
            hexTutorialDone = true;
            nodeUI.tutorialCounter = true;
            skipTutorialButton.SetActive(false);
        }
}
