using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    public Slider slider ;
    
    public GameObject settings;
    public void StartGame()
    {
        Application.LoadLevel(1);
    }
  
    public void ExitGame()
    {
        Application.Quit();
    }
 
   public void Save()
    {
        Application.LoadLevel(4);

    }
    private void Update() => AudioListener.volume = slider.value;
}
