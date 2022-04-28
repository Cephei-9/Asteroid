using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    [SerializeField] private Controler _startControler;
    [SerializeField] private Controler[] _controlers;

    public Controler ActiveControler { get; private set; }

    private void Start()
    {
        ActiveControler = _startControler;
    }

    public void ChangeControl(Controler controler)
    {
        foreach (var item in _controlers)
        {
            item.enabled = controler == item;
        }
        ActiveControler = controler;
    }
}
