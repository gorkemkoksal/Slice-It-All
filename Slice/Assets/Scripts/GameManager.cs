using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool game = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
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
