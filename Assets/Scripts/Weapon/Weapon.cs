using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    enum State { Idle, Fire, Reload }
    private State m_state = State.Idle;
    public Transform m_muzzle;  
    public Projectile bulletPrefab;
    private Coroutine m_fireCoroutine;
    private int ammo;
    private WeaponLego lego;
    public float Damage = 20;
    

    public Action onShoot;
    public Action onReloadStart;
    public Action onReloadEnd;

    public int Ammo { get => ammo; }
    public int MaxAmmo { get => lego.magazine.cage; }

    public void Awake()
    {
        lego = GetComponent<WeaponLego>();
        lego.GetElements();
        ammo = lego.magazine.cage;
    }
    public void GetElements()
    {
        lego.GetElements();
    }
    public void Pickup(IPart part)
    {
        lego.Pickup(part);
    }
    public void GoBase()
    {
        lego.GoBase();
    }

    public void Reload()
    {
        if (ammo != lego.magazine.cage && (m_state == State.Fire || m_state == State.Idle))
        {
            //Debug.Log($"перезарядка");
            m_state = State.Reload;
            onReloadStart?.Invoke();

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
        yield return new WaitForSeconds(lego.magazine.recharge);
        ammo = lego.magazine.cage;
        onReloadEnd?.Invoke();
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
            yield return new WaitForSeconds(lego.receiver.delay);
        }
        while(true);
    }
    private IEnumerator PostFireDelay()
    {
        yield return new WaitForSeconds(lego.receiver.delay);
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
        onShoot?.Invoke();
        //Debug.Log($"ammo - {ammo}");
        }
        else
        {
            //Debug.Log($"ammo - pusto {ammo}");
        }
    }

    public void ShootAction()
    {
        for (int i = 1; i <= lego.receiver.volume; i++)
        {
        Projectile bullet = Instantiate(bulletPrefab, m_muzzle.position, m_muzzle.rotation);

        Projectile projectileScript = bullet.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.maxDistance = lego.scope.range;
            projectileScript.damage = lego.totalDamage; 
        }
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float randomSpreadY = UnityEngine.Random.Range(-lego.scope.spread, lego.scope.spread);
            Vector3 spreadDirection = Quaternion.Euler(0, randomSpreadY, 0) * m_muzzle.forward;
            rb.AddForce(spreadDirection.normalized * lego.receiver.force, ForceMode.Impulse);
        }
        }
    }
}
