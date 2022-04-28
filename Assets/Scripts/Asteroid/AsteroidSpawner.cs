using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : Spawner<Asteroid>
{
    [SerializeField] private AsteroidCreator _creator;

    private int _remainsAsteroid;
    private int _nextAsteroidCount;
    private Balance.AsteroidBalance _characteristic;

    private void Start()
    {
        _characteristic = Balance.SingleTone.GetAsteroidBalance;
        _nextAsteroidCount = _characteristic.StartAsteroidCount;

        StartWave();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _creator.CreateNewAsteroid(GetRandomAsteroid(), _characteristic.GetRandomSpeed);
            //Debug.Break();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            FindObjectOfType<Asteroid>().Die();
        }
    }

    public void TakeAsteroidBorn(int countNewAsteroid) => _remainsAsteroid += countNewAsteroid;

    public void TakeAsteroidDeath()
    {
        _remainsAsteroid--;
        if (_remainsAsteroid <= 0) CreateNewWave();
    }

    private void StartWave()
    {
        for (int i = 0; i < _nextAsteroidCount; i++)
        {
            _creator.CreateNewAsteroid(GetAsteroidByIndex(2), _characteristic.GetRandomSpeed);
        }
        _nextAsteroidCount++;
    }

    private void CreateNewWave()
    {
        for (int i = 0; i < _nextAsteroidCount; i++)
        {
            _creator.CreateNewAsteroid(GetRandomAsteroid(), _characteristic.GetRandomSpeed);
        }
        _nextAsteroidCount++;
    }
}
