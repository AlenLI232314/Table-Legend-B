using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class MapView : MonoBehaviour
{
    /// <summary>
    /// Script for the map view button. When clicked, the camera shows the entire map, then returns to the
    /// player's POV when clicked again
    /// </summary>

    private Button thisButton;
    private GameManager gameManager;


    public CinemachineVirtualCamera mapCam, boardCam;
    public static event System.Action<CinemachineVirtualCamera> cameraEvent;
    bool onMapCam;

    // Start is called before the first frame update
    void Start()
    {
        mapCam.gameObject.SetActive(false);
        onMapCam = false;
    }

    //Called when this button is clicked
    public void Clicked()
    {
        Debug.Log("map view clicked");
        if (!onMapCam)
        {
           cameraEvent?.Invoke(mapCam);
        }
        else
        {
            cameraEvent?.Invoke(boardCam);
        }
        onMapCam = !onMapCam;
    }
}
