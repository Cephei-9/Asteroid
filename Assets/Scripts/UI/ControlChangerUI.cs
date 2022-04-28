using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlChangerUI : MonoBehaviour
{
    [SerializeField] private Controler _mouseControler;
    [SerializeField] private Controler _keyboardControler;
    [SerializeField] private MainControl _mainControle;
    [Space]
    [SerializeField] private Text _mouseText;
    [SerializeField] private Text _keyboardText;

    public void OnToggleValueChange(bool active)
    {
        Controler nextControler = _keyboardControler;
        if (active) nextControler = _mouseControler;
        _mainControle.ChangeControl(nextControler);

        ChangeText(active);
    }

    private void ChangeText(bool active)
    {
        _mouseText.enabled = active;
        _keyboardText.enabled = !active;
    }
}
