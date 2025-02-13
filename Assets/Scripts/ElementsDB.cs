using UnityEngine;

[CreateAssetMenu(fileName = "Element", menuName = "Element")]
public class ElementsDB : ScriptableObject
{
    [Header("Info")]
    [field: SerializeField] public string id { private set; get; }
    [field: SerializeField] public string ename  { private set; get; }
    [field: SerializeField] public string type { private set; get; }
    [field: SerializeField] public int rare { private set; get; }
    [field: SerializeField] public GameObject model { private set; get; }
    [field: SerializeField] public float damageRate { private set; get; }

    [Header("if scope")]
    [field: SerializeField] public float spread { private set; get; }
    [field: SerializeField] public float range { private set; get; }
    //[field: SerializeField] public float DamadeFactor2 { private set; get; }

    [Header("if magazine")]
    [field: SerializeField] public int cage { private set; get; }
    [field: SerializeField] public float recharge { private set; get; }
    // rechargeEvent

    [Header("if receiver")]
    [field: SerializeField] public float delay { private set; get; }
    [field: SerializeField] public float force { private set; get; }
    [field: SerializeField] public int volume { private set; get; }
}
