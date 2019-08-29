using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject Pause_Menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
          void Resume()
          {
            Pause_Menu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
          }
        void Pause()
        {
            Pause_Menu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;

        }
      
    }
   public void Resume()
   {
        Pause_Menu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
   }
    public void LoadMenu()
    {
        Application.LoadLevel(0);
        Resume();
    }
    public void ExitGame()
    {
        Application.Quit();
       
    }
}
