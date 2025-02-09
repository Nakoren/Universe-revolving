using UnityEngine;

public class ElementInfo : MonoBehaviour
{
    public ElementsDB elementDB;
    public void Awake()
    {
        // каким-то образом брать элемент из базы данных (лут)
    }
    public void GetInfo(ElementsDB element)
    {
        elementDB = element;
    }

}
