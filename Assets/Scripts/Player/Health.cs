using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private PlayerImmortalityAnimation _animation;
    [SerializeField] private Text _healthText;

    public UnityEvent PlayerDieEvent;
    public UnityEvent LoseEvent;

    public int CurentHealth { get; private set; }

    private Balance.PlayerBalance _characteristic;
    private bool _immortalytyActive;

    private void Start()
    {
        _characteristic = Balance.SingleTone.GetPlayerBalance;
        CurentHealth = _characteristic.Health;
        UpdateInfo();
    }

    public void Die()
    {
        if (_immortalytyActive) return;

        CurentHealth--;
        UpdateInfo();

        PlayerDieEvent.Invoke();

        if (CurentHealth <= 0) LoseEvent.Invoke();
    }

    public void StartImmortality()
    {
        _immortalytyActive = true;
        StartCoroutine(WaitEndImmortality());
        _animation.StartAnimation(_characteristic.TimeImmortality);
    }

    private void UpdateInfo() => _healthText.text = CurentHealth.ToString();

    private IEnumerator WaitEndImmortality()
    {
        yield return new WaitForSeconds(_characteristic.TimeImmortality);
        _immortalytyActive = false;
    }
}
