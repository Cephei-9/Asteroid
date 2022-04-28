using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _selfRb;

    private Balance.BulletBalance _characteristic;
    private float CalculateTimeToDie { get => ScreanParametrs.Width / _characteristic.Speed; }

    private void Awake()
    {
        _characteristic = FindObjectOfType<Balance>().GetBulletBalance;
    }

    public void Born(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        _selfRb.velocity = direction * _characteristic.Speed;

        StartCoroutine(WaitToDie(CalculateTimeToDie));
    }

    public void Die()
    {
        gameObject.SetActive(false);
        ObjectsPool.SingleTone.PutPrefab(this);
    }


    private IEnumerator WaitToDie(float time)
    {
        yield return new WaitForSeconds(time);
        Die();
    }
}
