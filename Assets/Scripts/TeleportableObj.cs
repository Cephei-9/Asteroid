using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportableObj : MonoBehaviour
{
    [SerializeField] private float _size;
    [SerializeField] private float _offset = 0.2f;
    [Space]
    [SerializeField] private Transform _selfTransform;

    public Vector3 Position { get => _selfTransform.position; }

    public void Teleport(Vector3 newPosition, Vector3 axis)
    {
        _selfTransform.position = newPosition + axis * (_size + _offset);
    }
}
