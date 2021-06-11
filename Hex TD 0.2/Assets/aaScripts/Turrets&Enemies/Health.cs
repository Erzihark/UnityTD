using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float max_health = 5000f;
    public float cur_health = 0f;
    public Image healthBar;
    public int worth;
    private bool checkAlive = true;
    public float TotalDamage = 0;
    private float poisonDamage = 0;
    private bool startPoison = false;

    float laserPopupTimer = 0f;
    float poisonTimer = 0f;

    public static int deadWallCounter = 0;

    public static bool gameOver = false;

    public bool isPoisoned;

    readonly string TagWall = "Wall";
    readonly string TagTurret = "Turret";
    readonly string TagEnemyLeft = "EnemyLeft";
    readonly string TagEnemyRight = "EnemyRight";

    void Start()
    {
        cur_health = max_health;

        if (healthBar != null)
        healthBar.fillAmount = cur_health / max_health;
    }


    public void takeDamage(float amount)
    {


        cur_health -= amount;
        healthBar.fillAmount = cur_health / max_health;
        if (healthBar.fillAmount < 0.8f && healthBar.fillAmount > 0.6f)
        {
            healthBar.color = new Color32(196, 255, 0, 100);
        }
        if (healthBar.fillAmount < 0.6f && healthBar.fillAmount > 0.4f)
        {
            healthBar.color = new Color32(247, 255, 0, 100);
        }
        if (healthBar.fillAmount < 0.4f && healthBar.fillAmount > 0.2f)
        {
            healthBar.color = new Color32(255, 162, 0, 100);
        }
        if (healthBar.fillAmount < 0.2f)
        {
            healthBar.color = new Color32(255, 43, 0, 100);
        }



        if (cur_health <= 0 && checkAlive)
        {
            Die();
            checkAlive = false;
        }
    }

    public void takeDamageLaser(float amount)
    {

        TotalDamage += amount;
        float f = TotalDamage;
        f = Mathf.Round(f * 10.0f) * 0.1f;

        cur_health -= amount;
        healthBar.fillAmount = cur_health / max_health;
        if (healthBar.fillAmount < 0.8f && healthBar.fillAmount > 0.6f)
        {
            healthBar.color = new Color32(196, 255, 0, 100);
        }
        if (healthBar.fillAmount < 0.6f && healthBar.fillAmount > 0.4f)
        {
            healthBar.color = new Color32(247, 255, 0, 100);
        }
        if (healthBar.fillAmount < 0.4f && healthBar.fillAmount > 0.2f)
        {
            healthBar.color = new Color32(255, 162, 0, 100);
        }
        if (healthBar.fillAmount < 0.2f)
        {
            healthBar.color = new Color32(255, 43, 0, 100);
        }



        if (cur_health <= 0 && checkAlive)
        {
            Die();
            checkAlive = false;
            TotalDamage = 0;
        }
    }

    public void Die()
    {
        // Destroy literally erases an objects existence, thats why I kept the spawner away from the turrets
        // cus if the turret kills the spawner then spawns will stop 

        if (gameObject.CompareTag(TagEnemyLeft) || gameObject.CompareTag(TagEnemyRight))
        {
            Destroy(this.gameObject);
            PlayerStats.money += worth;
            Wave.EnemiesAlive--;
            WaveSpawnerTopRight_Main.EnemyCount--;
        }

        else if (this.gameObject.CompareTag(TagWall))
        {

            if (this.gameObject.name == "Hex Wall TopRight")
            {
                BasicMovement.WallTopRightDestroyed = true;
                deadWallCounter++;
                Destroy(this.gameObject);

            }
            else if (this.gameObject.name == "Hex Wall TopLeft")
            {
                BasicMovement.WallTopLeftDestroyed = true;
                deadWallCounter++;
                Destroy(this.gameObject);
            }
            else if (this.gameObject.name == "Hex Wall BottomRight")
            {
                BasicMovement.WallBottomRightDestroyed = true;
                deadWallCounter++;
                Destroy(this.gameObject);
            }
            else if (this.gameObject.name == "Hex Wall BottomLeft")
            {
                BasicMovement.WallBottomLeftDestroyed = true;
                deadWallCounter++;
                Destroy(this.gameObject);
            }
        }

        else if (gameObject.CompareTag(TagTurret))
        {
            Destroy(this.gameObject);

        }

    }


    public void PoisonDamage(float amount)
    {
        isPoisoned = true;
        startPoison = true;
        if (amount > poisonDamage)
        {
            poisonDamage = amount;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        laserPopupTimer -= Time.deltaTime;
        poisonTimer -= Time.deltaTime;
        if(startPoison)
        {
            if(poisonTimer <= 0)
            {
                cur_health -= poisonDamage;
                healthBar.fillAmount = cur_health / max_health;

                if (healthBar.fillAmount < 0.8f && healthBar.fillAmount > 0.6f)
                {
                    healthBar.color = new Color32(196, 255, 0, 100);
                }
                else if (healthBar.fillAmount < 0.6f && healthBar.fillAmount > 0.4f)
                {
                    healthBar.color = new Color32(247, 255, 0, 100);
                }
                else if (healthBar.fillAmount < 0.4f && healthBar.fillAmount > 0.2f)
                {
                    healthBar.color = new Color32(255, 162, 0, 100);
                }
                else if (healthBar.fillAmount < 0.2f)
                {
                    healthBar.color = new Color32(255, 43, 0, 100);
                }
                if (cur_health <= 0 && checkAlive)
                {
                    Die();
                    checkAlive = false;
                    TotalDamage = 0;
                }
                poisonTimer = 0.5f;

            }
            
        }
    }
}
