using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PoisonPooler : MonoBehaviour
{
    public GameObject PoisonPrefab;
    public GameObject PoisonEffectPrefab;

    private Queue<GameObject> availablePoison = new Queue<GameObject>();
    private Queue<GameObject> availableEffects = new Queue<GameObject>();

    public static PoisonPooler Instance
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
        if (availablePoison.Count == 0)
            GrowPool();

            var instance = availablePoison.Dequeue();
            instance.SetActive(true);
            return instance;
        
    }

    private void GrowPool()
    {
        for (int i = 0; i < 5; i++)
        {
            var instanceToAdd = Instantiate(PoisonPrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availablePoison.Enqueue(instance);
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
            var effectInstanceToAdd = Instantiate(PoisonEffectPrefab);
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
