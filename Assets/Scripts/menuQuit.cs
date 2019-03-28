using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuQuit : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("User has quit");
        Application.Quit();
    }

 
}
