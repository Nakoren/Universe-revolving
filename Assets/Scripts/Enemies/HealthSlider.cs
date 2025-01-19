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
        hpStat = transform.Find("EnemyCanvas/Slider").gameObject.GetComponent<Slider>(); //ПЛОХО переделать на прямое прокидывапние ссылок
        canvas = transform.Find("EnemyCanvas").gameObject;
    }

    void Update()
    {
        if (canvas.transform.rotation != Camera.main.transform.rotation)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }
    //public IsVariableDefinedOption 


    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Projectile bullet = collision.gameObject.GetComponent<Projectile>(); //убрать в health
            if (bullet != null)
            {
                health.ReduceHealth(bullet.damage);
                hpStat.value = health.GetCurrentHealth()*100/health.GetMaxHealth();
            }

            Destroy(collision.gameObject);
        }
    }*/

}
