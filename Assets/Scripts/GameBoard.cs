using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private Vector3 _teleportAxis;
    [Space]
    [SerializeField] private Collider2D _oppositCollider;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.TryGetComponent(out TeleportableObj teleportableObj))
        {
            Vector3 oppositPoition = GetOppositPoition(teleportableObj.Position);
            teleportableObj.Teleport(oppositPoition, -1 * _teleportAxis);
        }
    }

    private Vector3 GetOppositPoition(Vector3 objPosition)
    {
        return _oppositCollider.ClosestPoint(objPosition);
    }
}
