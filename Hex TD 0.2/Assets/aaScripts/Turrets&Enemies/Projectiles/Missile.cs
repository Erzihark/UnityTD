using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject Maudio;
    private Transform target;

    public float damage;
    public float speed = 70f;
    public float SplashRadius = 0f;
    public GameObject impactEffect;
    public GameObject effectIns;

    Vector3 TargetPosition;
    Vector3 dir;

    private bool TargetAquired = false;

    public void Seek1(Transform _target)
    {
        target = _target;
    }


    void Update()
    {


        TargetAquired = true;
        float distancePerFrame = speed * Time.deltaTime;


        if (TargetAquired == true && target != null)
        {
            TargetPosition = target.position;
            dir = target.position - transform.position;
            transform.Translate(dir.normalized * distancePerFrame, Space.World); //moves the bullet
            transform.LookAt(target);

        }

        if (TargetAquired == true && target == null)
        {
            dir = TargetPosition - transform.position;
            transform.Translate(dir.normalized * distancePerFrame, Space.World); //moves the bullet
            transform.LookAt(target);


        }

        if (dir.magnitude <= distancePerFrame)
        {

            AudioPlay audioplay = Maudio.GetComponent<AudioPlay>();
            audioplay.PlayAudio();
            HitTarget();
            MissilePooler.Instance.AddToPool(gameObject);
            //Destroy(gameObject);
            TargetAquired = false;
            return;

        }


    }

    void HitTarget()
    {
        damage = Random.Range(damage - (damage / 10), damage + (damage / 10));


        if (SplashRadius > 0f)
        {
            Explode();
        }

        void Explode()
        {
            //effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            effectIns = MissilePooler.Instance.EffectGetFromPool();
            effectIns.transform.position = transform.position;
            effectIns.transform.rotation = transform.rotation;
            //Destroy(effectIns, 0.8f);
            Invoke("Destroy", 0.8f);
            //OverlapSphere creates a sphere and checks for all colliders that are in range of the sphere. Collider array to store all objects hit by sphere.
            Collider[] colliders = Physics.OverlapSphere(transform.position, SplashRadius);

            foreach (Collider collider in colliders) //for each object hit by the sphere, if tagged as Enemy then damage.
            {
                if (collider.tag == "EnemyTopLeft" || collider.tag == "EnemyTopRight" || collider.tag == "EnemyLeft" || collider.tag == "EnemyRight" || collider.tag == "EnemyBottomLeft" || collider.tag == "EnemyBottomRight")
                {
                    Damage(collider.transform);
                }
            }
        }

        void Damage(Transform target)
        {
            Health healthScript = target.transform.gameObject.GetComponent<Health>();

            healthScript.takeDamage(damage);
        }
        

    }
    void Destroy()
    {
        MissilePooler.Instance.EffectAddToPool(effectIns);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SplashRadius);
    }
}
