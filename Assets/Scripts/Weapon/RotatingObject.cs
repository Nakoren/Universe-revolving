using System;
using UnityEngine;

public class RotetingObgect : MonoBehaviour
{
    private PickupObject m_pickup;
    public float rotationSpeed = 50f;
    public GameObject cube;


    public void Awake()
    {
        m_pickup = GetComponent<PickupObject>();
        if (m_pickup.m_part != null) GetPart(m_pickup.m_part);
    }

    public void GetPart(IPart part)
    {
        ModelChange(part.model);
    }
    void Update()
    {
        //вращение
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
    

    private void ModelChange(GameObject m_model)
    {
        //var visual = Instantiate(m_model, this.transform);
        GameObject visual = Instantiate(m_model, transform.position, Quaternion.identity);
        visual.transform.SetParent(transform);
        visual.transform.localScale = new Vector3(3f, 3f, 3f);
        //visual.transform.SetParent(this.transform);
        cube.SetActive(false);
    }
}
