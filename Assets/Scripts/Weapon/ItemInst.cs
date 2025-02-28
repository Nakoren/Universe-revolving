using System;
using UnityEngine;
using static PartsDB;

public class ItemInst : MonoBehaviour
{
    private PartPickUpObject m_pickup;
    public GameObject roteting;
    public GameObject cube;


    public void Awake()
    {
        m_pickup = GetComponent<PartPickUpObject>();
        if (m_pickup.item != null) GetPart(m_pickup.item);
    }

    public void GetPart(Item item)
    {
        ModelChange(item.part.model);
    }
    

    private void ModelChange(GameObject m_model)
    {
        //var visual = Instantiate(m_model, this.transform);
        GameObject visual = Instantiate(m_model, transform.position, Quaternion.identity);
        visual.transform.SetParent(transform);
        visual.transform.localScale = new Vector3(3f, 3f, 3f);
        visual.transform.SetParent(roteting.transform);
        cube.SetActive(false);
    }
}
