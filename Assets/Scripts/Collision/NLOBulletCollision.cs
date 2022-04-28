using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLOBulletCollision : BulletCollision, IPlayerTaker
{
    protected override void OnCollision(CollisionObj collisionObj)
    {
        if (collisionObj.GetType() == typeof(NLOCollision)) return;
        base.OnCollision(collisionObj);
        if (collisionObj is INLOBulletTaker)
        {
            (collisionObj as INLOBulletTaker).Take();
        }
    }

    void IPlayerTaker.Take()
    {
        _bullet.Die();
    }
}
