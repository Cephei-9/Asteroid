using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLOCollision : CollisionObj, IPlayerBulletTaker
{
    [SerializeField] private NLO _nlo;

    protected override void OnCollision(CollisionObj collisionObj)
    {
        base.OnCollision(collisionObj);
        if (collisionObj is INLOTaker)
        {
            (collisionObj as INLOTaker).Take();
        }
    }

    void IPlayerBulletTaker.Take()
    {
        _nlo.Die();
    }
}
