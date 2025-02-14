using UnityEngine;

public class Receiver : IPart
{
    [field: SerializeField] public int rare { private set; get; }
    [field: SerializeField] public GameObject model { private set; get; }
    [field: SerializeField] public float damageRate { private set; get; }


    [field: SerializeField] public float delay { private set; get; }
    [field: SerializeField] public float force { private set; get; }
    [field: SerializeField] public int volume { private set; get; }
}
