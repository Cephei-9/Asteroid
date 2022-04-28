using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControler : Controler
{
    public Transform player;

    private void Update()
    {
        InputDirection = player.right * Input.GetAxisRaw("Horizontal");
        InputDirection = InputDirection.normalized;
        if (Input.GetAxisRaw("Horizontal") == 0) InputDirection = player.up;

        MoveInput = false;
        if (Input.GetAxisRaw("Vertical") == 1) MoveInput = true;

        if (Input.GetKeyDown(KeyCode.Space)) ShootInputEvent.Invoke();
    }
}
