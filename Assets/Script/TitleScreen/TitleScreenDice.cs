using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenDice : MonoBehaviour
{
    /// <summary>
    /// The primary script for the cool 3D dice on the title screen
    /// </summary>

    public GameObject mainCam;

    //The position of the dice so that it's always in the same space on screen even if the cam moves
    Vector3 dicePos;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the position (the camera's current pos with offsets added
        dicePos = new Vector3(mainCam.gameObject.transform.position.x + 0.614f,
                               mainCam.gameObject.transform.position.y - 1.425f,
                                mainCam.gameObject.transform.position.z + 0.82f);
        this.gameObject.transform.position = dicePos;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = dicePos;
    }
}
