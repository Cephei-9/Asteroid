using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private bool _isOpenMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isOpenMenu) 
                CloseMenu();
            else 
                OpenMenu();
        }
    }

    public void OpenMenu()
    {
        _isOpenMenu = true;
        _menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        _isOpenMenu = false;
        _menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
