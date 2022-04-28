using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    public void CreateNewAsteroid(Asteroid newAsteroid, float speed)
    {
        Vector3 randomPosition = GetRandomPositionOnField(out Vector3 directionForTeleport);
        Vector3 randomDirection = Random.insideUnitCircle;
        if (Vector3.Dot(randomDirection, directionForTeleport) < 0) randomDirection *= -1;

        newAsteroid.Born(Vector3.zero, randomDirection, speed);

        TeleportableObj teleportable = newAsteroid.transform.GetComponentInChildren<TeleportableObj>();
        teleportable.Teleport(randomPosition, directionForTeleport);
    }

    private Vector3 GetRandomPositionOnField(out Vector3 directionForTeleport)
    {
        float yPos = Random.Range(0, ScreanParametrs.Hight);
        float xPos = Random.Range(0, ScreanParametrs.Width);

        float sign = Random.Range(0, 2);
        float signForDirection = -((sign * 2) - 1);

        Vector3 randomVector = new Vector3(xPos, ScreanParametrs.Hight * sign);
        directionForTeleport = Vector3.up * signForDirection;
        if (xPos / ScreanParametrs.Width > yPos / ScreanParametrs.Hight)
        {
            randomVector = new Vector3(ScreanParametrs.Width * sign, yPos);
            directionForTeleport = Vector3.right * signForDirection;
        }
        return randomVector;
    }
}
