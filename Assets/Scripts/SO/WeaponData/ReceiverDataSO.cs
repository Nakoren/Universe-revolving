using UnityEngine;

[CreateAssetMenu(fileName = "Receiver", menuName = "Receiver")]
public class ReceiverDataSO : ScriptableObject
{
    public float delay = 0.5f;
    public float force = 20f;
    public int volume = 1;
}
