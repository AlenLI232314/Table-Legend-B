using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneManagement : MonoBehaviour
{
  
    public void quitButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void restartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
