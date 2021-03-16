using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenDiceSpin : MonoBehaviour
{
    /// <summary>
    /// Used on the big Dice on the title screen to make it spin
    /// </summary>
 
    // Update is called once per frame
    void OnMouseDrag()
    {
        //Made with https://www.youtube.com/watch?v=S3pjBQObC90
        float xRotaion = Input.GetAxis("Mouse X") * 10 * Mathf.Deg2Rad;
        float yRotation = Input.GetAxis("Mouse Y") * 10 * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -xRotaion);
        transform.RotateAround(Vector3.right, yRotation);

    }
}
