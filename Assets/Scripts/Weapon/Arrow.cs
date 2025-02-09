using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] public System.Action onDestroy;
    [SerializeField] public int damage = 10;
    private Vector3 startPosition;
    
    private float traveledDistance;
    public float maxDistance = 1f;

    private void Start()
    {
        int projectileLayer = LayerMask.NameToLayer("Projectile");
        Physics.IgnoreLayerCollision(projectileLayer, projectileLayer);
         transform.rotation = Quaternion.Euler(90, 0, 90);

    }
    public void Awake()
    {
        startPosition = transform.position;
        //transform.rotation = Quaternion.Euler(90, -90, 90); ;
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
