using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private int rotationOffset;


    private void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        Character.rotationCube += AdjustPlayerRotation;
    }

    private void OnDisable()
    {
        Character.rotationCube -= AdjustPlayerRotation;
    }

    void AdjustPlayerRotation(GameObject player)
    {
        player.transform.eulerAngles = new Vector3(
            player.transform.eulerAngles.x,
            player.transform.eulerAngles.y + rotationOffset,
            player.transform.eulerAngles.z);
    }
}
