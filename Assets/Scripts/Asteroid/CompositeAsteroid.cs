using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeAsteroid : Asteroid
{
    [SerializeField] private Asteroid _smallAsteroid;

    public override void Die()
    {
        BornNewAsteroid();
        base.Die();
    }

    private void BornNewAsteroid()
    {
        float sign = 1;
        float speed = Balance.SingleTone.GetAsteroidBalance.GetRandomSpeed;

        for (int i = 0; i < 2; i++)
        {
            Asteroid asteroid = (Asteroid)ObjectsPool.SingleTone.TakePrefab(_smallAsteroid.GetType());
            Vector3 newDirection = CalculateNewDirection(sign, _characteristic.AngleBetwinAsteroids);
            asteroid.Born(transform.position, newDirection.normalized, speed);

            sign = -1;
        }
    }

    private Vector3 CalculateNewDirection(float sign, float angle)
    {
        Vector3 direction;
        if (angle > 45)
        {
            float koifAngle = Mathf.InverseLerp(45, 90, angle);
            direction = transform.up + (transform.right * sign) - (transform.up * koifAngle);
        }
        else
        {
            float koifAngle = Mathf.InverseLerp(0, 45, angle);
            direction = transform.up + (transform.right * sign * koifAngle);
        }
        return direction.normalized;
    }
}

