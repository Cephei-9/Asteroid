using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Controler : MonoBehaviour
{
    public Vector3 InputDirection { get; protected set; }
    public bool MoveInput { get; protected set; }
    public UnityEvent ShootInputEvent;
}
