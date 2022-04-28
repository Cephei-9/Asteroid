using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScrean : MonoBehaviour
{
    [SerializeField] private float _waitTime = 1;
    [SerializeField] private GameObject _loseObj;
    [SerializeField] private GameObject _playerSprite;
    [SerializeField] private Text _scoreText;

    public void OnLose()
    {
        _playerSprite.SetActive(false);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_waitTime);
        _scoreText.text = "Your Score: " + ScoreSystem.SingleTone.Score.ToString();
        Time.timeScale = 0;
        _loseObj.SetActive(true);
    }
}
