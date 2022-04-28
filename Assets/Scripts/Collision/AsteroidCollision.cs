using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidCollision : CollisionObj, IBulletTaker
{
    [SerializeField] private Asteroid _asteroid;

    protected override void OnCollision(CollisionObj collisionObj)
    {
        base.OnCollision(collisionObj);
        if (collisionObj is IAsteroidTaker)
        {
            (collisionObj as IAsteroidTaker).Take();
        }
    }

    void IBulletTaker.Take()
    {
        _asteroid.Die();
    }
}
