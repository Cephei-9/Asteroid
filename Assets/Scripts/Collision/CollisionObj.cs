using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObj : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out CollisionObj collisionObj))
        {
            OnCollision(collisionObj);
        }
    }

    protected virtual void OnCollision(CollisionObj collisionObj)
    {
        if(collisionObj is ICollisionTaker)
        {
            (collisionObj as ICollisionTaker).Take(); 
        }
    }
}
