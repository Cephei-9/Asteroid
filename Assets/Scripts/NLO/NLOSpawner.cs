using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLOSpawner : Spawner<NLO>
{
    private Balance.NLOBalance _characteristic;

    private void Start()
    {
        _characteristic = Balance.SingleTone.GetNLOBalance;

        CreateNLO();
        StartCoroutine(SpawnNLO());
    }

    private void CreateNLO()
    {
        NLO nlo = GetRandomAsteroid();
        Vector3 position = GetRandomPositionOnField(out Vector3 direction);
        nlo.Born(position, direction, _characteristic.Speed);
        nlo.GetComponentInChildren<TeleportableObj>().Teleport(position, direction);
    }

    private Vector3 GetRandomPositionOnField(out Vector3 directionForTeleport)
    {
        float signLeftRight = Random.Range(0, 2);
        float hight = ScreanParametrs.Hight;
        float percentByOne = _characteristic.PercentOfset / 100;
        float randomHight = Random.Range(hight * percentByOne, hight - hight * percentByOne);

        directionForTeleport = -((signLeftRight * 2) - 1) * Vector3.right;
        return Vector3.right * ScreanParametrs.Width * signLeftRight + Vector3.up * randomHight;
    }

    private IEnumerator SpawnNLO()
    {
        while (true)
        {
            float timeToNextShoot = Random.Range(_characteristic.MinTimeSpawn, _characteristic.MaxTimeSpawn);
            yield return new WaitForSeconds(timeToNextShoot);

            CreateNLO();
        }
    }
}
