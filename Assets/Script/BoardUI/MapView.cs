using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapView : MonoBehaviour
{
    /// <summary>
    /// Script for the map view button. When clicked, the camera shows the entire map, then returns to the
    /// player's POV when clicked again
    /// </summary>

    private Button thisButton;
    private GameManager gameManager;

    public CameraManagement camManagement;

    // Start is called before the first frame update
    void Start()
    {
        //assigns the button (which you attatch this script to) and the gamemanager
        thisButton = GetComponent<Button>();

        thisButton.onClick.AddListener(Clicked);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Called when this button is clicked
    public void Clicked()
    {
        camManagement.resetCamera();
    }
}
