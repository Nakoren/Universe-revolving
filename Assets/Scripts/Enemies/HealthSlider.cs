using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HealthSlider : MonoBehaviour
{
    private Slider hpStat;
    private Health health;
    private GameObject canvas;

    void Start()
    {
        health = GetComponent<Health>();
        hpStat = transform.Find("EnemyCanvas/Slider").gameObject.GetComponent<Slider>();
        canvas = transform.Find("EnemyCanvas").gameObject;
    }

    void Update()
    {
        if (canvas.transform.rotation != Camera.main.transform.rotation)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Projectile bullet = collision.gameObject.GetComponent<Projectile>();
            if (bullet != null)
            {
                health.ReduceHealth(bullet.damage);
                hpStat.value = health.GetCurrentHealth()*100/health.GetMaxHealth();
            }

            Destroy(collision.gameObject);
        }
    }

}
