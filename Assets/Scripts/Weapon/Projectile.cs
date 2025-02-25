using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public System.Action onDestroy;
    [SerializeField] public float damage = 10;
    private Vector3 startPosition;
    private float traveledDistance;
    public float maxDistance = 1f;

    private void Start()
    {
        int enemyProjectileLayer = LayerMask.NameToLayer("ProjectileEnemy");
        int playerProjectileLayer = LayerMask.NameToLayer("ProjectilePlayer");
        int playerLayer = LayerMask.NameToLayer("Player");
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        Physics.IgnoreLayerCollision(enemyProjectileLayer, playerProjectileLayer);
        Physics.IgnoreLayerCollision(enemyProjectileLayer, enemyLayer);
        Physics.IgnoreLayerCollision(playerProjectileLayer, playerLayer);
    }
    public void Awake()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        traveledDistance = Vector3.Distance(startPosition, transform.position);

        if (traveledDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.ReduceHealth(damage);
        }

        if(onDestroy != null)
        {
            onDestroy.Invoke();
        }
        Destroy(gameObject);
    }
}
