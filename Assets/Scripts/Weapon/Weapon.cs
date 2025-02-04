using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    enum State { Idle, Fire, Reload }
    private State m_state = State.Idle;
    public Transform m_muzzle;  
    public Projectile bulletPrefab;
    private Coroutine m_fireCoroutine;

    private ScopeElement m_scopeElement;
    private MagazineElement m_magazineElement;
    private ReciverElement m_reciverElement;
    private int ammo;


    public void Awake()
    {
        GetElements();
        ammo = m_magazineElement.magazineData.cage;
    }

    public void GetElements()
    {
        m_scopeElement = GetComponentInChildren<ScopeElement>();
        m_magazineElement = GetComponentInChildren<MagazineElement>();
        m_reciverElement = GetComponentInChildren<ReciverElement>();
    }

    public void Reload()
    {
        if (ammo != m_magazineElement.magazineData.cage && (m_state == State.Fire || m_state == State.Idle))
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
        yield return new WaitForSeconds(m_magazineElement.magazineData.recharge);
        ammo = m_magazineElement.magazineData.cage;
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
            yield return new WaitForSeconds(m_reciverElement.receiverData.delay);
        }
        while(true);
    }
    private IEnumerator PostFireDelay()
    {
        yield return new WaitForSeconds(m_reciverElement.receiverData.delay);
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
        for (int i = 1; i <= m_reciverElement.receiverData.volume; i++)
        {
        Projectile bullet = Instantiate(bulletPrefab, m_muzzle.position, m_muzzle.rotation);

        Projectile projectileScript = bullet.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.maxDistance = m_scopeElement.scopeData.range;
        }
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float randomSpreadY = Random.Range(-m_scopeElement.scopeData.spread, m_scopeElement.scopeData.spread);
            Vector3 spreadDirection = Quaternion.Euler(0, randomSpreadY, 0) * m_muzzle.forward;
            rb.AddForce(spreadDirection.normalized * m_reciverElement.receiverData.force, ForceMode.Impulse);
        }
        }
    }
}
