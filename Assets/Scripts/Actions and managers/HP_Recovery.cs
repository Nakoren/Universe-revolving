using UnityEngine;

public class HP_Recovery : MonoBehaviour
{
    private SphereCollider sphereCollider;

    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health health = other.GetComponent<Health>();

            if (health != null)
            {
                health.RestoreFullHealth();
                this.enabled=false;
            }
        }
    }
}
