using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour
    where T : Component
{
    [System.Serializable]
    private class SpawnObj
    {
        public T Prefab;
        public float Chanse = 0.5f;
    }

    [SerializeField] private SpawnObj[] _spawnObjs;
    [Space]
    [SerializeField] private ObjectsPool _objectsPool;

    protected T GetRandomAsteroid()
    {
        float maxChance = 0;
        int index = 0;
        for (int i = 0; i < _spawnObjs.Length; i++)
        {
            float itemChance = _spawnObjs[i].Chanse * UnityEngine.Random.value;
            if (itemChance > maxChance)
            {
                maxChance = itemChance;
                index = i;
            }
        }
        return GetAsteroidByIndex(index);
    }

    protected T GetAsteroidByIndex(int index)
    {
        Type nextAsteroidType = _spawnObjs[index].Prefab.GetType();
        T asteroid = (T)_objectsPool.TakePrefab(nextAsteroidType);
        return asteroid;
    }
}
