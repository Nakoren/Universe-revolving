using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnBullet;
    public float shootForce;
    public ScopeDataSO scopeData;
    public ReceiverDataSO receiverData;
    public MagazineDataSO magazineData;
    private int ammo = 0;
    public void Awake()
    {
        ammo = magazineData.cage;
    }

    public void Reload()
    {
        ammo = magazineData.cage;
    }
    public void StartReload()
    {
        Reload();
    }

    public void ShootAction()
    {
        
        BulletCounter();
        if (ammo > 0)
        {
            ShootToTarget();;
        }
    }

    public void BulletCounter()
    {
        if (ammo > 0)
        {
        ammo = ammo - 1;
        Debug.Log($"ammo - {ammo}");
        }
        else
        {
            Debug.Log($"ammo - pusto {ammo}");
        }
    }

    public void ShootToTarget()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float randomSpreadY = Random.Range(-scopeData.spread, scopeData.spread);
            Vector3 spreadDirection = Quaternion.Euler(0, randomSpreadY, 0) * spawnBullet.forward;
            rb.AddForce(spreadDirection.normalized * shootForce, ForceMode.Impulse);
        }
    }
}
