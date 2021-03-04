using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 initialPosition;
    [SerializeField]
    private Vector3 offset;
    void Start()
    {
        initialPosition = this.transform.position;
        offset = initialPosition - player.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        
    }
}
