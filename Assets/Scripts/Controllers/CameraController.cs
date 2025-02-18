using NUnit.Framework.Interfaces;
using System.Drawing;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] public GameObject target;
    [SerializeField] Vector3 offset;
    [SerializeField] public bool followCursor;
    [Header("For correct execution this need to be set not less then to 4")]
    [SerializeField] int negativeFollowForce;


    Transform m_targetTransform;

    private void Awake()
    {

    }

    private void Start()
    {
        if (target != null)
        {
            m_targetTransform = target.transform;
            cameraTransform.position = m_targetTransform.position + offset;
            cameraTransform.LookAt(m_targetTransform);
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        this.target = newTarget;
        m_targetTransform = target.transform;
        cameraTransform.position = m_targetTransform.position + offset;
        cameraTransform.LookAt(m_targetTransform);
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
        cameraTransform.position = newPosition;
    }
}
