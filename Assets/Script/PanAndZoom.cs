using Cinemachine;
using UnityEngine;

public class PanAndZoom : MonoBehaviour
{

    private CinemachineInputProvider inputProvider;
    private CinemachineVirtualCamera virtualCamera;
    private Transform cameraTransform;

    [SerializeField]
    private float panSpeed = 2f;
    [SerializeField]
    private float zoomSpeed = 3f;
    [SerializeField]
    private float zoomInMax = 40f;
    [SerializeField]
    private float zoomOutMax = 90f;
    private void Awake()
    {
        inputProvider = GetComponent<CinemachineInputProvider>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cameraTransform = virtualCamera.VirtualCameraGameObject.transform;

    }
    void Start()
    {
        
    }

    void Update()
    {
        float x = inputProvider.GetAxisValue(0);
        float y = inputProvider.GetAxisValue(1);
        float z = inputProvider.GetAxisValue(2);
        //Debug.Log("x: "+x+" y: "+y+" z: "+z);

        if (x != 0 || y != 0)
        {
            PanScreen(x, y);
        }

        if (z != 0)
        {
            ZoonScreen(z);
        }
    }

    public void ZoonScreen(float increment)
    {
        float fov = virtualCamera.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov - increment, zoomInMax, zoomOutMax);
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomSpeed * Time.deltaTime);
    } 

    public Vector3 PanDirection(float x, float y)
    {
        Vector3 direction = Vector3.zero;
        if (y >= Screen.height * .95f)
        {
            direction.z -= 2;
            if(x <= (Screen.width/2))
            {
                direction.x += 2;
            }
        }
        if (y <= Screen.height * .05f)
        {
            direction.z += 2;
            if (x >= (Screen.width / 2))
            {
                direction.x -= 2;
            }
        }
        if (x >= Screen.width * .95f)
        {
            direction.x -= 2;
        }
        if (x <= Screen.width * 0.05f)
        {
            direction.x += 2;
        }
        return direction;
    }
    public void PanScreen(float x,float z)
    {
        Vector3 direction = PanDirection(x, z);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraTransform.position + (Vector3)direction * panSpeed, Time.deltaTime);
    }
}
