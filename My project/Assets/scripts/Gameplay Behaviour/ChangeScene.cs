using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SwitchScene()
    {
        // Get the current scene
        Scene current = SceneManager.GetActiveScene();

        // Switch to the other scene
        if (current.name == "Menu")
        {
            SceneManager.LoadScene("Game");
        }
        else if (current.name == "Game")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
