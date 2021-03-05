using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthButton : MonoBehaviour
{

    /// <summary>
    /// A script to be attatched to testing buttons changing player health
    /// </summary>
    private Button thisButton;
    private GameManager gameManager;

    // Determines what value to add/remove from player health when the button is pressed. Assigned in the Editor
    public int healthToGiveOrTake;

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
        gameManager.ChangeHealth(healthToGiveOrTake);
    }
}
