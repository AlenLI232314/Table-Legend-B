using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private bool worldCamera = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeCameras()
    {
        if (worldCamera)
        {
            animator.Play("CombatCamera");
        }
        else if (!worldCamera)
        {
            animator.Play("WorldCamera");
        }

        worldCamera = !worldCamera;

    }
}
