using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class OxygenUI : MonoBehaviour
{
    public Text oxygenText;
    int oxygen;
    int previousOxygen = 0;

    private float timeSinceLastCalled;
    public static float oxygenDepleteRate = 1000; //time in secs

    private float previousWallCrack1 = 0;
    private float previousWallCrack2 = 0;
    private float previousWallCrack3 = 0;
    private float previousWallCrack4 = 0;
    private float previousWallCrack5 = 0;
    private float previousWallCrack6 = 0;

    private int previousDeadWallCounter = 0;

    bool startupUpdate = false;
  
    void Update()
    {
        oxygen = PlayerStats.oxygen;
        if (startupUpdate == false)
        {
            UpdateOxygen();
            startupUpdate = true;
        }

        if (oxygen > 0)
        {
            if (Health.deadWallCounter != previousDeadWallCounter || ChangeMaterialColor.wallCrack1 != previousWallCrack1
            || ChangeMaterialColor.wallCrack2 != previousWallCrack2 || ChangeMaterialColor.wallCrack3 != previousWallCrack3
            || ChangeMaterialColor.wallCrack4 != previousWallCrack4 || ChangeMaterialColor.wallCrack5 != previousWallCrack5
            || ChangeMaterialColor.wallCrack6 != previousWallCrack6)

            {
                oxygenDepleteRate = 5f / (Health.deadWallCounter + ChangeMaterialColor.wallCrack1 + ChangeMaterialColor.wallCrack2
                        + ChangeMaterialColor.wallCrack3 + ChangeMaterialColor.wallCrack4
                        + ChangeMaterialColor.wallCrack5 + ChangeMaterialColor.wallCrack6);

                // Debug.Log(oxygenDepleteRate);

                if (Health.deadWallCounter != previousDeadWallCounter)
                {
                    previousDeadWallCounter = Health.deadWallCounter;
                }
                if (ChangeMaterialColor.wallCrack1 != previousWallCrack1)
                {
                    previousWallCrack1 = ChangeMaterialColor.wallCrack1;
                }
                if (ChangeMaterialColor.wallCrack2 != previousWallCrack2)
                {
                    previousWallCrack2 = ChangeMaterialColor.wallCrack2;
                }
                if (ChangeMaterialColor.wallCrack3 != previousWallCrack3)
                {
                    previousWallCrack3 = ChangeMaterialColor.wallCrack3;
                }
                if (ChangeMaterialColor.wallCrack4 != previousWallCrack4)
                {
                    previousWallCrack4 = ChangeMaterialColor.wallCrack4;
                }
                if (ChangeMaterialColor.wallCrack5 != previousWallCrack5)
                {
                    previousWallCrack5 = ChangeMaterialColor.wallCrack5;
                }
                if (ChangeMaterialColor.wallCrack6 != previousWallCrack6)
                {
                    previousWallCrack6 = ChangeMaterialColor.wallCrack6;
                }  
            }
            timeSinceLastCalled += Time.deltaTime;
            if (timeSinceLastCalled > oxygenDepleteRate )
            {
                PlayerStats.oxygen--;
                timeSinceLastCalled = 0;
                if (oxygen != previousOxygen)
                {
                    UpdateOxygen();
                    previousOxygen = oxygen;
                }
            }
        }
    }
    public void UpdateOxygen()
    {
        oxygenText.text = PlayerStats.oxygen.ToString();
    }
}