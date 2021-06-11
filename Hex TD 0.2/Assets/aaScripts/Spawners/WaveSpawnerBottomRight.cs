using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawnerBottomRight : MonoBehaviour
{

    // public static int EnemiesAlive = 0;

    public static int EnemyCount = 0;

    public Wave[] waves;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;
    public Transform Target1;
    public Transform Target2;
    public Transform Target3;
    public Transform Target4;
    public Transform Target5;
    private int spawnSpacer = 1;

    public static bool waverushed;
    private bool waveStarterPlaced;

    GameObject clone;

    public Transform WaveIndicatorPosition;
    public GameObject waveStarter;
    public GameObject waveIndicator;
    private bool waveIndicatorPlaced;
    private bool noEnemiesComing = false;

    private int waveIndex = 0;

    public void WaveRushed()

    {
        waverushed = true;
    }
    void Update()
    {
        if (WaveSpawnerTopRight_Main.tutorialOn == true)
            return;

        if (WaveSpawnerTopRight_Main.startFirstWave <= 0 && !waveStarterPlaced)
        {
            Wave wave = waves[waveIndex];
            waveIndex++;
            if (wave.count == 0)
            {
                noEnemiesComing = true;

            }
            else
            {
                noEnemiesComing = false;
            }

            if (noEnemiesComing == false)
            {
                waveStarter.SetActive(true);
                Instantiate(waveStarter, WaveIndicatorPosition.position, Quaternion.Euler(90f, 90f, -30f));
                waveStarterPlaced = true;

            }
            waveIndex--;

        }

        if (WaveSpawnerTopRight_Main.countdown <= 0f || waverushed == true)
        {
            StartCoroutine(SpawnWave());
            waverushed = false;
            waveIndicatorPlaced = false;
            return;
        }

        if (Wave.EnemiesAlive == 0 && waveIndex != waves.Length)
        {
            Wave wave = waves[waveIndex];
            waveIndex++;
            if (wave.count == 0)
            {
                noEnemiesComing = true;

            }
            else
            {
                noEnemiesComing = false;
            }

            if (waveIndicatorPlaced == false && waveIndex > 1 && noEnemiesComing == false)
            {
                waveIndicator.SetActive(true);
                Instantiate(waveIndicator, WaveIndicatorPosition.position, Quaternion.Euler(90f, 90f, -30f));

                waveIndicatorPlaced = true;
            }
            waveIndex--;

        }

    }

    IEnumerator SpawnWave()
    {


        Wave wave = waves[waveIndex];

        EnemyCount = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        switch (spawnSpacer)
        {
            case 1:
                Vector3 position1 = new Vector3(1, 0, 1);

                BasicMovement basicMovement1 = enemy.transform.gameObject.GetComponent<BasicMovement>();
                basicMovement1.MoveTarget(Target1);
                clone = Instantiate(enemy, spawnPoint1.position + position1, spawnPoint1.rotation);
                clone.tag = "EnemyRight";
                Wave.EnemiesAlive++;
                spawnSpacer++;
                

                break;

            case 2:
                Vector3 position2 = new Vector3(1, 0, 1);

                BasicMovement basicMovement2 = enemy.transform.gameObject.GetComponent<BasicMovement>();
                basicMovement2.MoveTarget(Target2);
                clone = Instantiate(enemy, spawnPoint2.position + position2, spawnPoint2.rotation);
                clone.tag = "EnemyRight";
                Wave.EnemiesAlive++;
                spawnSpacer++;
                
                break;
            case 3:
                Vector3 position3 = new Vector3(1, 0, 1);

                BasicMovement basicMovement3 = enemy.transform.gameObject.GetComponent<BasicMovement>();
                basicMovement3.MoveTarget(Target3);
                clone = Instantiate(enemy, spawnPoint3.position + position3, spawnPoint3.rotation);
                clone.tag = "EnemyRight";
                Wave.EnemiesAlive++;
                spawnSpacer++;
                
                break;

            case 4:
                Vector3 position4 = new Vector3(1, 0, 1);

                BasicMovement basicMovement4 = enemy.transform.gameObject.GetComponent<BasicMovement>();
                basicMovement4.MoveTarget(Target4);
                clone = Instantiate(enemy, spawnPoint4.position + position4, spawnPoint4.rotation);
                clone.tag = "EnemyRight";
                Wave.EnemiesAlive++;
                spawnSpacer++;
                
                break;
            case 5:
                Vector3 position5 = new Vector3(1, 0, 1);

                BasicMovement basicMovement5 = enemy.transform.gameObject.GetComponent<BasicMovement>();
                basicMovement5.MoveTarget(Target5);
                clone = Instantiate(enemy, spawnPoint5.position + position5, spawnPoint5.rotation);
                clone.tag = "EnemyRight";
                Wave.EnemiesAlive++;
                spawnSpacer = 1;
                

                break;


        }
    }

}