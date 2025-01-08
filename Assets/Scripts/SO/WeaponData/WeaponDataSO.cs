using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class WeaponDataSO : ScriptableObject
{
    public GameObject bulletPrefab;
    public ScopeDataSO scopeData;
    public ReceiverDataSO receiverData;
    public MagazineDataSO magazineData;
}
