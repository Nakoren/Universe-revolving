using UnityEngine;

[CreateAssetMenu(fileName = "Scope", menuName = "Parts/Scope")]
public class Scope : IPart
{

    [field: SerializeField] public float spread { private set; get; }
    [field: SerializeField] public float range { private set; get; }

}
