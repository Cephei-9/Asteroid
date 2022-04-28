using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreanParametrs : MonoBehaviour
{
    public static float Hight
    {
        get
        {
            if (_hight == default) _hight = Camera.main.orthographicSize * 2; 
            return _hight;
        }
    }

    public static float Width
    { 
        get
        {
            if (_width == default) _width = Camera.main.orthographicSize* Camera.main.aspect * 2;
            return _width;
        }
    }

    public static Vector3 ScreanCentr { get => Vector3.right * Width / 2 + Vector3.up * Hight / 2; }

    private static float _hight;
    private static float _width;
}
