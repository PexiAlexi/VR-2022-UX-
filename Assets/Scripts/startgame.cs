using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{

     public void Startaspel (string sceneName)
    {

        SceneManager.LoadScene(sceneName);
    }
        
}
