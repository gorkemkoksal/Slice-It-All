using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool game;
    [SerializeField] private Menu menu;
    [SerializeField] private CoinManager coinManager;
    
    void Start()
    {
        game = false;
    }

    
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && game == false && !menu.MarketisOpen)
        {
            game = true;

            menu.MainMenu.SetActive(false);
            menu.MenuInGame.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            EndLevel();
        }
    }

    public void EndLevel()
    {
        game = false;

        menu.WinPanel.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Scene Name");
    }

    private void NextLevel()
    {
        SceneManager.LoadScene("Scene Name");
    }
}
