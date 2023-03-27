using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool game;
    [SerializeField] private Menu menu;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private Movement movement;
    
    void Start()
    {
        game = false;
    }

    
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.M))
        {
            menu.OpenMarketMenu();
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            menu.MainMenu.SetActive(false);
            menu.MenuInGame.SetActive(true);
        }
        
    }

    public void EndLevel()
    {
        game = false;

        menu.WinPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    /*private void NextLevel()
    {
        SceneManager.LoadScene("Scene Name");
    }*/
}
