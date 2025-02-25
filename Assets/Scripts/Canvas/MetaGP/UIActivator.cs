using NUnit.Framework;
using UnityEngine;

public class UIActivator : MonoBehaviour
{
    [SerializeField] GameObject[] activatable_objects;

    private void OnEnable()
    {
        foreach (GameObject item in activatable_objects)
        {
            item.SetActive(true)    ;
        }
    }
    private void OnDisable()
    {
        foreach (GameObject item in activatable_objects)
        {
            if (item != null)
            {
                item.SetActive(false);
            }
        }
    }
}
