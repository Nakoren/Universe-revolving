using UnityEngine;

public class WeaponVisual : MonoBehaviour
{
    public Transform mainBody;
    public Transform scopeBody;
    public Transform magazineBody;
    public Transform receiverBody;
    public Vector3 localPositionOffset; 


    public void SetElementScope(IPart part)
    {
        if (part != null) DestroyAllChildrenOf(scopeBody);
        GameObject visual = Instantiate(part.model, scopeBody.position, Quaternion.identity);
        visual.transform.SetParent(scopeBody);
        visual.transform.rotation = magazineBody.rotation;
        //visual.transform.localPosition = scopeBody.position;
    }
    public void SetElementMagazine(IPart part)
    {
        if (part != null) DestroyAllChildrenOf(magazineBody);
        GameObject visual = Instantiate(part.model, magazineBody.position, Quaternion.identity);
        visual.transform.SetParent(magazineBody);
        visual.transform.rotation = magazineBody.rotation;
        //visual.transform.localPosition = scopeBody.position;
    }
    public void SetElementReceiver(IPart part)
    {
        if (part != null) DestroyAllChildrenOf(receiverBody);
        GameObject visual = Instantiate(part.model, receiverBody.position, Quaternion.identity);
        visual.transform.SetParent(receiverBody);
        visual.transform.rotation = receiverBody.rotation;
        //visual.transform.localPosition = scopeBody.position;
    }
    public void DestroyAllChildrenOf(Transform parent)
    {
        if (parent == null)
        {
            Debug.LogWarning("Родительский объект не задан!");
            return;
        }

        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}
