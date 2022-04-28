using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImmortalityAnimation : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [Space]
    [SerializeField] private SpriteRenderer renderer;

    public void StartAnimation(float timeWork)
    {
        StartCoroutine(Animate(timeWork));
    }

    private IEnumerator Animate(float timeWork)
    {
        Sprite playerSprite = renderer.sprite;
        for (float t = 0; t < timeWork; t += Time.deltaTime)
        {
            float tSpeed = Mathf.RoundToInt((t * _speed) % 1);
            renderer.sprite = null;
            if (tSpeed > 0.5f) renderer.sprite = playerSprite;
            yield return null;
        }
        renderer.sprite = playerSprite;
    }
}
