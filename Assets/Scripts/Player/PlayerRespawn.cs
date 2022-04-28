using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private float _timeToRespawn = 0.5f;
    [SerializeField] private float _respawnRadius = 4;
    [SerializeField] private float _checkBoxSize = 4;
    [Space]
    [SerializeField] private Transform _playerTransform;

    public UnityEvent RespawnEvent;

    public void OnPlayerDie()
    {
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        _playerTransform.gameObject.SetActive(false);

        yield return new WaitForSeconds(_timeToRespawn);

        Vector3 newPosition = Vector3.zero;
        for (int i = 0; i < 150; i++)
        {
            newPosition = ScreanParametrs.ScreanCentr + (Vector3)Random.insideUnitCircle * _respawnRadius;
            Collider2D InsideCheckBox = Physics2D.OverlapBox(newPosition, Vector2.one * _checkBoxSize, 0);
            if (InsideCheckBox == null) break;
        }

        _playerTransform.position = newPosition;
        _playerTransform.gameObject.SetActive(true);

        RespawnEvent.Invoke();
    }
}
