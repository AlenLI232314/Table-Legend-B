using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteTriggerTest : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    //set trigger on when player enter the collider

    void OnTriggerEnter(Collider other)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
        
    }

   


}
