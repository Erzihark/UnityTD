using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animattack : MonoBehaviour
{
    private Animator anim;

    Collision collisionTurret = null;
    Collision collisionWall = null;
    Collision collisionCenter = null;

    GameObject CollisionTurret;
    GameObject CollisionWall;
    GameObject CollisionCenter;

    private bool CollidedWithTurret = false;
    private bool CollidedWithWall = false;
    private bool CollidedWithCenter = false;


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Turret")
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

        if (CollidedWithWall)
        {
            anim.SetBool("IsAttacking", true);
           
        }
        else if (CollidedWithTurret)
        {
            anim.SetBool("IsAttacking", true);
        }
        else if (CollidedWithCenter)
        {
            anim.SetBool("IsAttacking", true);
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }
    }


      
}

