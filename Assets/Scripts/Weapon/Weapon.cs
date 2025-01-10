using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform m_muzzle;
    public WeaponDataSO weaponDataSO;
    private Coroutine m_fireCoroutine;
    public void StartFire()
    {
        m_fireCoroutine = StartCoroutine(FireDelay());
    }

    private IEnumerator FireDelay()
    {
        do
        {
            Shoot();
            yield return new WaitForSeconds(weaponDataSO.receiverData.delay);
        }
        while(true);
    }

    public void StopFire()
    {
        if (m_fireCoroutine != null)
        {
            StopCoroutine(m_fireCoroutine);
            m_fireCoroutine = null;
        }
    }
    public void Shoot()
    {
        for (int i = 1; i <= weaponDataSO.receiverData.volume; i++)
        {
        GameObject bullet = Instantiate(weaponDataSO.bulletPrefab, m_muzzle.position, m_muzzle.rotation);

        Projectile projectileScript = bullet.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.maxDistance = weaponDataSO.scopeData.range;
        }
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float randomSpreadY = Random.Range(-weaponDataSO.scopeData.spread, weaponDataSO.scopeData.spread);
            Vector3 spreadDirection = Quaternion.Euler(0, randomSpreadY, 0) * m_muzzle.forward;
            rb.AddForce(spreadDirection.normalized * weaponDataSO.receiverData.force, ForceMode.Impulse);
        }
        }
    }
}
