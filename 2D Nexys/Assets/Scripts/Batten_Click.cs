using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Batten_Click : MonoBehaviour
{
   
    public void LoadLVL1()
    {
        Application.LoadLevel(1);

        
    }
    public void LoadLVL2()
    {
        Application.LoadLevel(2);


    }
    public void LoadLVL3()
    {
        Application.LoadLevel(3);


    }
 
    public void LoadMenu()
    {
        Application.LoadLevel(0);


    }
}
