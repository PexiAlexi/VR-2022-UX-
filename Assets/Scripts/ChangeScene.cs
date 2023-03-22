using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // Assign the name of the scene to load in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        
         SceneManager.LoadScene(sceneName);
       
    }
}
