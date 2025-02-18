using System.Drawing;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] GameObject target;
    [SerializeField] Vector3 offset;
    [SerializeField] public bool followCursor;
    [Header("For correct execution this need to be set not less then to 4")]
    [SerializeField] int negativeFollowForce;


    Transform m_camTransform;
    Transform m_targetTransform;

    private void Awake()
    {
        
    }

    private void Start()
    {
        m_camTransform = cam.transform;
        m_targetTransform = target.transform;
        m_camTransform.position = m_targetTransform.position + offset;
        m_camTransform.LookAt(m_targetTransform);
    }

    private Vector3 GetCameraOffsetToCursor()
    {
        Vector3 rayCastPoint;
        LayerMask pointerRaycastMask = LayerMask.GetMask("Pointer Raycast");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;

        if (Physics.Raycast(ray, out rayHit, 1000, pointerRaycastMask))
        {
            rayCastPoint = rayHit.point;
            rayCastPoint.y = 0;
            Vector3 tempTargetPosition = m_targetTransform.position;
            tempTargetPosition.y = 0;
            return (rayCastPoint - tempTargetPosition)/negativeFollowForce;
        }
        else 
        { 
            return new Vector3(); 
        }
        
    }

    void Update()
    {
        Vector3 newPosition = m_targetTransform.position + offset;
        if (followCursor)
        {
            newPosition += GetCameraOffsetToCursor();
        }
        m_camTransform.position = newPosition;
    }
}
