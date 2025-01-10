using UnityEngine;

[CreateAssetMenu(fileName = "Magazine", menuName = "Magazine")]
public class MagazineDataSO : ScriptableObject
{
    [field: SerializeField] public int cage { private set; get; } = 10;
    [field: SerializeField] public float recharge { private set; get; } = 1f;
    // rechargeEvent
}
