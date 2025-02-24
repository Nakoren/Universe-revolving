using UnityEngine;

[CreateAssetMenu(fileName = "Magazine", menuName = "Parts/Magazine")]
public class Magazine : IPart
{
    [field: SerializeField] public int cage { private set; get; }
    [field: SerializeField] public float recharge { private set; get; }
    // rechargeEvent
}
