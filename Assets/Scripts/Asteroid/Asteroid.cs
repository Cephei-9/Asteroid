using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private int _score = 100;
    [Space]
    [SerializeField] private Rigidbody2D _selfRb;
    [SerializeField] private AsteroidSpawner _spawner;
    [SerializeField] protected Balance.AsteroidBalance _characteristic;

    private void Awake()
    {
        _spawner = FindObjectOfType<AsteroidSpawner>();
        _characteristic = FindObjectOfType<Balance>().GetAsteroidBalance;
    }

    public virtual void Born(Vector3 position, Vector3 direction, float speed)
    {
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        _selfRb.velocity = direction.normalized * speed;

        _spawner.TakeAsteroidBorn(1);
    }

    public virtual void Die()
    {
        ObjectsPool.SingleTone.PutPrefab(this);
        ScoreSystem.SingleTone.AddScore(_score);
        _spawner.TakeAsteroidDeath();
        SoundMenager.SingleTone.PlaySoundByName(SoundNames.Explosion, Mathf.InverseLerp(130, 0, _score));
    }   
}
