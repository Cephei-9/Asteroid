using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [System.Serializable]
    public class NLOBalance
    {
        public float Speed;
        public float MinShootPeriod;
        public float MaxShootPeriod;
        [Space]
        public float MinTimeSpawn;
        public float MaxTimeSpawn;

        public float PercentOfset;
    }

    [System.Serializable]
    public class AsteroidBalance
    {
        public float MinSpeed;
        public float MaxSpeed;
        [Space]
        [Range(0, 90)]
        public float AngleBetwinAsteroids;
        [Space]
        public int StartAsteroidCount;

        public float GetRandomSpeed { get => Random.Range(MinSpeed, MaxSpeed); }
    }

    [System.Serializable]
    public class PlayerBalance
    {
        public float MaxSpeed;
        public float Acceleration;
        public float AngularVelosity;
        [Space]
        public float ShootPeriod;
        [Space]
        public int Health;
        public int TimeImmortality;
    }

    [System.Serializable]
    public class BulletBalance
    {
        public float Speed;
    }

    [SerializeField] private NLOBalance _NLOBalance;
    public NLOBalance GetNLOBalance { get => _NLOBalance; }
    [Space]
    [SerializeField] private AsteroidBalance _asteroidBalance;
    public AsteroidBalance GetAsteroidBalance { get => _asteroidBalance; }
    [Space]
    [SerializeField] private PlayerBalance _playerBalance;
    public PlayerBalance GetPlayerBalance { get => _playerBalance; }
    [Space]
    [SerializeField] private BulletBalance _bulletBalance;
    public BulletBalance GetBulletBalance { get => _bulletBalance; }

    public static Balance SingleTone { get; private set; }

    private void Awake()
    {
        if (SingleTone != null) Debug.LogError("SingleToneExeption");
        SingleTone = this;
    }
}
