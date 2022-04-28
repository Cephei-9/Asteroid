using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : BulletCollision, INLOTaker
{
    protected override void OnCollision(CollisionObj collisionObj)
    {
        base.OnCollision(collisionObj);
        if (collisionObj is IPlayerBulletTaker)
        {
            (collisionObj as IPlayerBulletTaker).Take();
        }
    }

    void INLOTaker.Take()
    {
        _bullet.Die();
    }
}
