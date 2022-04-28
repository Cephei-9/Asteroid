using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : CollisionObj, IAsteroidTaker, INLOBulletTaker
{
    public Health _health;

    protected override void OnCollision(CollisionObj collisionObj)
    {
        base.OnCollision(collisionObj);
        if(collisionObj is IPlayerTaker)
        {
            (collisionObj as IPlayerTaker).Take();
        }
    }

    void IAsteroidTaker.Take()
    {
        _health.Die();
    }

    void INLOBulletTaker.Take()
    {
        _health.Die();
    }
}
