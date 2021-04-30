using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    /// <summary>
    /// Script that handles all the events for the pressable buttons on the title screen
    /// </summary>
    ///

    //The options and credits menu UI panels
    public GameObject OptionsMenu, Credits, CreditsScreen2;

    //Called when the start button is pressed, changes the scene to the one passed, whether that be the first level
    //or a later one (if we end up implementing saving)
    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    //Quits the game. called when the quit button is pressed
    public void QuitGame()
    {
        Application.Quit();
    }

    //Opens or closes the Options menu
    public void OptionsButton()
    {
        OptionsMenu.SetActive(!OptionsMenu.activeInHierarchy);
    }

    //Opens or closes the credits display
    public void CreditsButton()
    {
        

        if(CreditsScreen2.activeInHierarchy)
        {
            CreditsScreen2.SetActive(false);
        }
        else
        {
           Credits.SetActive(!Credits.activeInHierarchy);
        }
    }
}
