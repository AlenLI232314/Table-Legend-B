using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenDice : MonoBehaviour
{
    /// <summary>
    /// The primary script for the cool 3D dice on the title screen
    /// </summary>

    //The position of the dice so that it's always in the same space on screen even if the cam moves
    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(UnityEngine.Random.Range(-1f, .1f), UnityEngine.Random.Range(-1f, .1f), UnityEngine.Random.Range(-1f, .1f));
    }

    // Update is called once per frame
    void Update()
    {
        DiceRotate();
    }

    //Rotates the dice
    void DiceRotate()
    {
        this.gameObject.transform.Rotate(rotation);
    }
}
