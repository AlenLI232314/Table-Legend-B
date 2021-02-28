using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Time.timeScale = 1f;
            animator.Play("CombatCamera");
        }
        else if (!worldCamera)
        {
            Time.timeScale = 1f;
            animator.Play("WorldCamera");
        }

        worldCamera = !worldCamera;

    }
}
