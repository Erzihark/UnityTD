using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletEffectPrefab;

    private Queue<GameObject> availableBullets = new Queue<GameObject>();
    private Queue<GameObject> availableEffects = new Queue<GameObject>();

    public static BulletPooler Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Instance = this;
        GrowPool();
        EffectGrowPool();
    }

    public GameObject GetFromPool()
    {
        if (availableBullets.Count == 0)
            GrowPool();

            var instance = availableBullets.Dequeue();
            instance.SetActive(true);
            return instance;
        
    }

    private void GrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(bulletPrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableBullets.Enqueue(instance);
    }

    public GameObject EffectGetFromPool()
    {
        if (availableEffects.Count == 0)
            EffectGrowPool();

        var effectInstance = availableEffects.Dequeue();
        effectInstance.SetActive(true);
        return effectInstance;

    }

    private void EffectGrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var effectInstanceToAdd = Instantiate(bulletEffectPrefab);
            effectInstanceToAdd.transform.SetParent(transform);
            EffectAddToPool(effectInstanceToAdd);
        }
    }

    public void EffectAddToPool(GameObject effectInstance)
    {
        effectInstance.SetActive(false);
        availableEffects.Enqueue(effectInstance);
    }



}
