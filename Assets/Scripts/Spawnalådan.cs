using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnalådan : MonoBehaviour
{
    
    void Start()
    {
        GameObject myObject = GameObject.FindGameObjectWithTag("Trashcan");
        myObject.SetActive(false);
    }

    public void SetVisible()
    {
        GameObject myObject = GameObject.FindGameObjectWithTag("Trashcan");
        myObject.SetActive(true);
    }
}
