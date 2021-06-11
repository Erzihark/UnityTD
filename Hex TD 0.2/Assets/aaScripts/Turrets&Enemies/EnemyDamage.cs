using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    public float attackSpeed;

    private float damageCountdown = 0f;

    public Transform target;


    private bool CollidedWithTurret = false;
    private bool CollidedWithWall = false;
    private bool CollidedWithCenter = false;


    Collision collisionTurret = null;
    Collision collisionWall = null;
    Collision collisionCenter = null;

    GameObject CollisionTurret;
    GameObject CollisionWall;
    GameObject CollisionCenter;


    public void OnCollisionEnter(Collision collision)
    {     
        if(collision.transform.tag == "Turret")
        {
            CollidedWithTurret = true;
            
            this.collisionTurret = collision;
            CollisionTurret = collision.transform.gameObject;

        }

        if (collision.transform.tag == "Wall")
        {
            CollidedWithWall = true;
            this.collisionWall = collision;
            CollisionWall = collision.transform.gameObject;
        }
        if (collision.transform.tag == "Center")
        {

            CollidedWithCenter = true;
            this.collisionCenter = collision;
            CollisionCenter = collision.transform.gameObject;
            

        }
    }

    public void OnCollisionExit(Collision collision)
    {       
        if (collision.transform.tag == "Turret")
        {
            CollidedWithTurret = false;
            
            this.collisionTurret = collision;
            CollisionTurret = null;
        }
        if (collision.transform.tag == "Wall")
        {

            CollidedWithWall = false;
            this.collisionWall = collision;
            CollisionWall = null;
        }
    }
    

    private void Update()
    {
        damageCountdown -= Time.deltaTime;

        if (CollidedWithWall)
        {

            if (CollisionWall != null)
            {
                if (damageCountdown <= 0)
                {
                    
                    Health healthScript = collisionWall.transform.gameObject.GetComponent<Health>();
                    healthScript.cur_health -= damage;

                    damageCountdown = 1f / attackSpeed;


                    if (healthScript.cur_health <= 0)
                    {
                        CollidedWithWall = false;
                        healthScript.Die();
                    }
                }
            }
        }

        if (CollidedWithTurret)
        {
            if (CollisionTurret != null)
            {
            if (damageCountdown <= 0)
            {
                
                Health healthScript = collisionTurret.transform.gameObject.GetComponent<Health>();
                healthScript.cur_health -= damage;

                damageCountdown = 1f / attackSpeed;


                if (healthScript.cur_health <= 0)
                {
                    CollidedWithTurret = false;
                    healthScript.Die();
                }
            }
            }
        }
        if (CollidedWithCenter)
        {

            if (CollisionCenter != null)
            {
                WaveSpawnerTopRight_Main.levelFailed = true;
                
            }
        }
    }

}





