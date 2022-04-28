using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _selfRb;
    [SerializeField] private MainControl _mainControl;

    public Vector3 Direction { get; private set; }

    private Balance.PlayerBalance _characteristic;

    private void Start()
    {
        _characteristic = Balance.SingleTone.GetPlayerBalance;
    }

    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_mainControl.ActiveControler.MoveInput == false) return;

        _selfRb.AddForce(Direction * _characteristic.Acceleration, ForceMode2D.Impulse);
        Vector3 velosity = _selfRb.velocity;
        _selfRb.velocity = velosity.normalized * Mathf.Min(_characteristic.MaxSpeed, velosity.magnitude);
    }

    private void Rotate()
    {
        Quaternion toInputDirection = Quaternion.LookRotation(Vector3.forward, _mainControl.ActiveControler.InputDirection);
        Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, toInputDirection, _characteristic.AngularVelosity);
        _selfRb.MoveRotation(newRotation);
        Direction = transform.up;
    }
}
