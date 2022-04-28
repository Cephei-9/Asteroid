using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Gun
{
    [Header("PlayerGun")]
    [SerializeField] private Transform _bulletSpawn;

    public bool CanShoot { get; private set; } = true;

    private Balance.PlayerBalance _characteristic;

    private void Start()
    {
        _characteristic = Balance.SingleTone.GetPlayerBalance;
    }

    private void OnDisable()
    {
        CanShoot = true;
    }

    public void Shoot()
    {
        if (CanShoot == false) return;

        base.Shoot(_bulletSpawn.position, _bulletSpawn.up);
        StartCoroutine(ReCharge());
    }

    private IEnumerator ReCharge()
    {
        CanShoot = false;
        yield return new WaitForSeconds(_characteristic.ShootPeriod);
        CanShoot = true;
    }
}
