using UnityEngine;

[CreateAssetMenu(fileName = "Scope", menuName = "Scope")]
public class ScopeDataSO : ScriptableObject
{
    [field: SerializeField] public float spread { private set; get; } = 1f;
    [field: SerializeField] public float range { private set; get; } = 15;
    [field: SerializeField] public float DamadeFactor2 { private set; get; } = 1;
}
