using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisCameraTracker : MonoBehaviour
{

    /// <summary>
    /// Moves the invisible cube that the camera tracks on the title screen
    /// </summary>
    /// 
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x >= -.5 || this.gameObject.transform.position.x <= -16.2)
        {
            direction *= -1;
        }

        gameObject.transform.Translate(new Vector3(direction, 0, 0) * Time.deltaTime);
    }
}
