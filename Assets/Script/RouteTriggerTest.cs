using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteTriggerTest : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
        
    }

   


}
