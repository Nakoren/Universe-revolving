using UnityEngine;

public class TestHPRecover : MonoBehaviour
{
    [SerializeField] private Health healthComponent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            healthComponent.RestoreHealth(1);
        }
    }
}
