using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Baudio;
    private Transform target;

    public float damage;
    public float speed = 70f;
    public float SplashRadius = 0f;
    public GameObject impactEffect;
    public GameObject effectIns;

    Vector3 TargetPosition;
    Vector3 dir;

    private bool TargetAquired = false;


    public void Seek(Transform _target)
    {
        target = _target;
    }


    void Update()
    {


        TargetAquired = true;
        float distancePerFrame = speed * Time.deltaTime;


        if (TargetAquired == true && target != null)
        {
            TargetPosition = new Vector3(target.position.x, target.position.y + 0.5f, target.position.z);
            dir = new Vector3(target.position.x, target.position.y + 0.5f, target.position.z) - transform.position;
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
            
            HitTarget();
            AudioPlay1 audioplay = Baudio.GetComponent<AudioPlay1>();
            audioplay.PlayAudio();
            BulletPooler.Instance.AddToPool(gameObject);
            TargetAquired = false;
            return;

        }


    }

     void HitTarget()
    {
        damage = Random.Range(damage - (damage / 10), damage + (damage / 10));



        if (target != null)
        {
            //GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation); 
            effectIns = BulletPooler.Instance.EffectGetFromPool();
            effectIns.transform.position = transform.position;
            effectIns.transform.rotation = transform.rotation;
            
            //BulletPooler.Instance.EffectAddToPool(effectIns);
            Invoke("Enqueue", 0.3f);

            //Destroy(effectIns, 0.2f);
            Damage(target);
        }


        void Damage(Transform target)
        {
            Health healthScript = target.transform.gameObject.GetComponent<Health>();

            healthScript.takeDamage(damage);



        }

    }
    void Enqueue()
    {
        BulletPooler.Instance.EffectAddToPool(effectIns);
    }




    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SplashRadius);
    }
}

