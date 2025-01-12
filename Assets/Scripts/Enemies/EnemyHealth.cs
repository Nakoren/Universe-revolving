using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public int HP;
    private  int HPconst;
    private Slider hpStat;
    private GameObject canvas;

    void Start()
    {
        HPconst=HP;
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

    public void GetDamage(int damage)
    {
        HP -= damage;
        hpStat.value = HP*100/HPconst;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Projectile bullet = collision.gameObject.GetComponent<Projectile>();
            if (bullet != null)
            {
                GetDamage(bullet.Damage);
            }

            Destroy(collision.gameObject);
        }
    }

}
