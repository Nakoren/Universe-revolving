using UnityEngine;

public class Scope : IPart
{
    [field: SerializeField] public int rare { private set; get; }
    [field: SerializeField] public GameObject model { private set; get; }
    [field: SerializeField] public float damageRate { private set; get; }


    [field: SerializeField] public float spread { private set; get; }
    [field: SerializeField] public float range { private set; get; }

}
