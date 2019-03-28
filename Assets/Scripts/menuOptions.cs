using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuOptions : MonoBehaviour {

    // Use this for initialization
    public void changeToScene(int changeTheScene)
    {
        Application.LoadLevel(changeTheScene);
    }

}
