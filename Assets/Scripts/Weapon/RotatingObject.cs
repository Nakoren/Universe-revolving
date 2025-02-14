using System;
using UnityEngine;

public class RotetingObgect : MonoBehaviour
{
    private PickupObject m_pickup;
    public float rotationSpeed = 50f;


    public void Awake()
    {

    }

    public void GetPart()
    {
        m_pickup = GetComponent<PickupObject>();
        ModelChange();
    }
    void Update()
    {
        //вращение
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
    

    private void ModelChange()
    {
        var visual = Instantiate(m_pickup.m_part.model, this.transform.position, this.transform.rotation);
        visual.transform.SetParent(this.transform);
    }
}
