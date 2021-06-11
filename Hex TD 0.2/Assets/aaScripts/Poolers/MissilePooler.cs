using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MissilePooler : MonoBehaviour
{
    public GameObject missilePrefab;
    public GameObject missileEffectPrefab;

    private Queue<GameObject> availableMissiles = new Queue<GameObject>();
    private Queue<GameObject> availableEffects = new Queue<GameObject>();

    public static MissilePooler Instance
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
        if (availableMissiles.Count == 0)
            GrowPool();

            var instance = availableMissiles.Dequeue();
            instance.SetActive(true);
            return instance;
        
    }

    private void GrowPool()
    {
        for (int i = 0; i < 5; i++)
        {
            var instanceToAdd = Instantiate(missilePrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableMissiles.Enqueue(instance);
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
        for (int i = 0; i < 5; i++)
        {
            var effectInstanceToAdd = Instantiate(missileEffectPrefab);
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
