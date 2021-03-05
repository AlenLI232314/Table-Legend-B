using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpButton : MonoBehaviour
{
    /// <summary>
    /// A script to be attatched to the testing button giving the player XP
    /// </summary>
    // Start is called before the first frame update
    private Button thisButton;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //assigns the button (which you attatch this script to) and the gamemanager
        thisButton = GetComponent<Button>();

        thisButton.onClick.AddListener(Clicked);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Called when this button is clicked
    void Clicked()
    {
        gameManager.giveXp(10);
    }
}
