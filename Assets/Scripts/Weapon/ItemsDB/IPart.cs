using UnityEngine;

public abstract class IPart : ScriptableObject
{
    [field: SerializeField] public int type { private set; get; }
    [field: SerializeField] public GameObject model { private set; get; }
    [field: SerializeField] public float damageRate { private set; get; }
}
