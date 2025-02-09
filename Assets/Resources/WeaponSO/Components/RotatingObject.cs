using System;
using UnityEngine;

public class RotetingObgect : MonoBehaviour
{
    ElementInfo m_element;
    public float rotationSpeed = 50f;
    // private MeshFilter meshFilter;
    // private MeshRenderer meshRenderer;

    void Update()
    {
        //вращение
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
    public void Awake()
    {
        //m_element = GetComponent<ElementInfo>();
        //ModelChange();
    }

    private void ModelChange()
    {
        var element = Instantiate(m_element.elementDB.model, this.transform);
        element.transform.localPosition = Vector3.zero;
        // if (m_element.elementDB.model != null)
        // {
        //     // Получаем MeshFilter и MeshRenderer целевого объекта
        //     MeshFilter targetMeshFilter = m_element.elementDB.model.GetComponent<MeshFilter>();
        //     MeshRenderer targetMeshRenderer = m_element.elementDB.model.GetComponent<MeshRenderer>();

        //     if (targetMeshFilter != null && targetMeshRenderer != null)
        //     {
        //         // Копируем Mesh и применяем его к текущему объекту
        //         meshFilter = GetComponent<MeshFilter>();
        //         meshRenderer = GetComponent<MeshRenderer>();

        //         if (meshFilter != null)
        //         {
        //             meshFilter.mesh = Instantiate(targetMeshFilter.mesh);
        //         }

        //         if (meshRenderer != null)
        //         {
        //             meshRenderer.materials = targetMeshRenderer.materials; // Копируем материалы
        //         }
        //     }
        //     else
        //     {
        //         Debug.LogWarning("Target object does not have a MeshFilter or MeshRenderer component.");
        //     }
        // }
        // else
        // {
        //     Debug.LogWarning("Target object is not assigned.");
        // }
    }
}
