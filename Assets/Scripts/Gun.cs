using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private AudioSource _audio;

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Bullet bullet = (Bullet)ObjectsPool.SingleTone.TakePrefab(_bulletPrefab.GetType());
        bullet.Born(origin, direction.normalized);
        SoundMenager.SingleTone.PlaySoundByName(SoundNames.Fire);
    }
}
