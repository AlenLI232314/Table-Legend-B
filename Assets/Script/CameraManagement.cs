using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

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

    void OnEnable()
    {
        Monster.cameraEvent += OnCameraEventHeard;
    }

    void OnDisable()
    {
        Monster.cameraEvent -= OnCameraEventHeard;
    }

    public void changeCameras()
    {
        if (!worldCamera)
        {
            Time.timeScale = 1f;
            animator.Play("WorldCamera");
            worldCamera = true;
        }

    }

    void OnCameraEventHeard(CinemachineVirtualCamera cam)
    {

        cam.gameObject.SetActive(true);

        if (worldCamera && cam.gameObject.name == "CombatCam1")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam1");
        }

        if (worldCamera && cam.gameObject.name == "CombatCam2")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam2");
        }

        if (worldCamera && cam.gameObject.name == "CombatCam3")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam3");
        }

        if (worldCamera && cam.gameObject.name == "CombatCam4")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam4");
        }

        if (worldCamera && cam.gameObject.name == "CombatCam5")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam5");
        }

        if (worldCamera && cam.gameObject.name == "CombatCam6")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam6");
        }

        if (worldCamera && cam.gameObject.name == "CombatCam7")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam7");
        }

        if (worldCamera && cam.gameObject.name == "CombatCam8")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam8");
        }

        if (worldCamera && cam.gameObject.name == "CombatCam9")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam9");
        }

        if (worldCamera && cam.gameObject.name == "CombatCam10")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam10");
        }

        if (worldCamera && cam.gameObject.name == "CombatCam11")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("CombatCam11");
        }

        if (worldCamera && cam.gameObject.name == "IntroCam")
        {
            worldCamera = !worldCamera;

            Time.timeScale = 1f;
            animator.Play("IntroCam");
        }

    }
}
