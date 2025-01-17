using System.Drawing;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cam;
    public GameObject target;
    public Vector3 offset;

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

    void Update()
    {
        m_camTransform.position = m_targetTransform.position + offset;
    }
}
