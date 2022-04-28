using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLO : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private int _score = 1;
    [SerializeField] private Vector2 _minMaxShootPeriod;
    [Space]
    [SerializeField] private Rigidbody2D _selfRb;
    [SerializeField] private Gun _gun;

    private Transform _player;
    private Balance.NLOBalance _characteristic;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMove>().transform;
        _characteristic = FindObjectOfType<Balance>().GetNLOBalance;
    }

    public virtual void Born(Vector3 position, Vector3 direction, float speed)
    {
        transform.position = position;
        _selfRb.velocity = direction.normalized * speed;
        StartCoroutine(Shoot());
    }

    public virtual void Die()
    {
        ObjectsPool.SingleTone.PutPrefab(this);
        ScoreSystem.SingleTone.AddScore(_score);
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            float timeToNextShoot = Random.Range(_characteristic.MinShootPeriod, _characteristic.MaxShootPeriod);
            yield return new WaitForSeconds(timeToNextShoot);
            Vector3 toPlayer = _player.position - transform.position;
            _gun.Shoot(transform.position, toPlayer);
        }
    }
}
