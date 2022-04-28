using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : CollisionObj, IAsteroidTaker, IBulletTaker
{
    [SerializeField] protected Bullet _bullet;

    protected override void OnCollision(CollisionObj collisionObj)
    {
        base.OnCollision(collisionObj);
        if(collisionObj is IBulletTaker)
        {
            (collisionObj as IBulletTaker).Take();
        }
    }

    void IAsteroidTaker.Take()
    {
        _bullet.Die();   
    }

    void IBulletTaker.Take()
    {
        _bullet.Die();
    }
}
