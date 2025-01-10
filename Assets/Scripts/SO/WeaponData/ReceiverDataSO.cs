using UnityEngine;

[CreateAssetMenu(fileName = "Receiver", menuName = "Receiver")]
public class ReceiverDataSO : ScriptableObject
{
    [field: SerializeField] public float delay { private set; get; } = 0.5f;
    [field: SerializeField] public float force { private set; get; } = 20f;
    [field: SerializeField] public int volume { private set; get; } = 1;
}
