using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private Transform _rightBoard;
    [SerializeField] private Transform _leftBoard;

    private void Start()
    {
        transform.position = Vector3.up * ScreanParametrs.Hight / 2 + Vector3.right * ScreanParametrs.Width / 2; 
        _rightBoard.position = transform.position + Vector3.right * ((ScreanParametrs.Width / 2) + 0.5f);
        _leftBoard.position = transform.position + Vector3.right * ((-ScreanParametrs.Width / 2) - 0.5f);
    }
}