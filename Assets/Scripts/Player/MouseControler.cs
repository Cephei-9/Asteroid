using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControler : Controler
{
    [SerializeField] private Transform _player; 
    [SerializeField] private Camera _mainCamera;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        plane.Raycast(ray, out float distance);
        Vector3 mousePos = ray.GetPoint(distance);
        InputDirection = mousePos - _player.position;

        MoveInput = false;
        if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.W)) MoveInput = true;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) ShootInputEvent.Invoke();
    }
}
