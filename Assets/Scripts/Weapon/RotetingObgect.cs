using UnityEngine;

public class RotetingObgect : MonoBehaviour
{
    public float rotationSpeed = 200f;
    void Update()
    {
        //вращение
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
