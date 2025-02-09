using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int damage = 20;
    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.ReduceHealth(damage);
        }
    }
}
