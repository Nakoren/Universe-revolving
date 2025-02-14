using UnityEngine;

public abstract class IPart : ScriptableObject
{
    public enum Ptype { Scope, Magazine, Receiver }
    public Ptype type;
    [field: SerializeField] public GameObject model { private set; get; }
    [field: SerializeField] public float damageRate { private set; get; }
}
