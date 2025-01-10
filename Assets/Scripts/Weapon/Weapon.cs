using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    enum State { Idle, Fire, Reload }
    public Transform m_muzzle;
    public WeaponDataSO weaponDataSO;
    private Coroutine m_fireCoroutine;
    private State m_state = State.Idle;
    private int ammo;
    public void Awake()
    {
        ammo = weaponDataSO.magazineData.cage;
    }

    public void Reload()
    {
        if (ammo != weaponDataSO.magazineData.cage && (m_state == State.Fire || m_state == State.Idle))
        {
            Debug.Log($"перезарядка");
            m_state = State.Reload;
            StartCoroutine(ReloadDelay());
            if (m_fireCoroutine != null)
            {
                StopCoroutine(m_fireCoroutine);
                m_fireCoroutine = null;
            }
        }
    }
    private IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(weaponDataSO.magazineData.recharge);
        ammo = weaponDataSO.magazineData.cage;
        m_state = State.Idle;
    }
    public void StartFire()
    {
        if (ammo <= 0 && m_state == State.Idle)
        {
            Reload();
            return;
        }
        
        if (m_state == State.Idle)
        {
            m_state = State.Fire;
            m_fireCoroutine = StartCoroutine(FireDelay());
        }
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
    private IEnumerator PostFireDelay()
    {
        yield return new WaitForSeconds(weaponDataSO.receiverData.delay);
        m_state = State.Idle;
    }

    public void StopFire()
    {
        if (m_fireCoroutine != null)
        {
            StopCoroutine(m_fireCoroutine);
            m_fireCoroutine = null;
        }

        if (m_state == State.Fire)
        {
            StartCoroutine(PostFireDelay());
        }
    }

    public void Shoot()
    {
        BulletCounter();
        if (ammo > 0)
        {
            ShootAction();;
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

    public void ShootAction()
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
