using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] public int damage = 10;

    private void Start()
    {
        int projectileLayer = LayerMask.NameToLayer("Projectile");
        Physics.IgnoreLayerCollision(projectileLayer, projectileLayer);
    }
  

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.ReduceHealth(damage);
        }
    }
}
