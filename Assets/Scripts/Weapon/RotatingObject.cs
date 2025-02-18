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
        ModelChange(m_pickup.m_part.model);
    }

    public void GetPart(GameObject m_model)
    {
        ModelChange(m_model);
    }
    void Update()
    {
        //вращение
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
    

    private void ModelChange(GameObject m_model)
    {
        var visual = Instantiate(m_model, this.transform);
        //visual.transform.SetParent(this.transform);
        cube.SetActive(false);
    }
}
