using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PartsDB;

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
    public int MaxAmmo = 228;

    public void Awake()
    {
        lego = GetComponent<WeaponLego>();
        var partM = lego.magazine.part as Magazine; 
        ammo = partM.cage;
        MaxAmmo = partM.cage;
    }
    
    public void ToDefault()
    {
        lego.ToDefault();
    }
    
    public void Pickup(Item item)
    {
        lego.Pickup(item);
    }
    public void GoBase()
    {
        lego.GoBase();
    }

    public void Reload()
    {
        var partM = lego.magazine.part as Magazine; 
        if (ammo != partM.cage && (m_state == State.Fire || m_state == State.Idle))
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
        var partM = lego.magazine.part as Magazine; 
        yield return new WaitForSeconds(partM.recharge);
        ammo = partM.cage;
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
        var partR = lego.receiver.part as Receiver; 
        do
        {
            Shoot();
            yield return new WaitForSeconds(partR.delay);
        }
        while(true);
    }
    private IEnumerator PostFireDelay()
    {
        var partR = lego.receiver.part as Receiver; 
        yield return new WaitForSeconds(partR.delay);
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
        if (ammo > 0)
        {
            Debug.Log($"SHOOTammo - {ammo}");
            ShootAction();
        }
         BulletCounter();
    }

    public void BulletCounter()
    {
        if (ammo > 0)
        {
        ammo = ammo - 1;
        onShoot?.Invoke();
        Debug.Log($"ammo - {ammo}");
        }
        else
        {
            Debug.Log($"ammo - pusto {ammo}");
        }
    }

    private IEnumerator MultyFier()
    {
        yield return new WaitForSeconds(0.2f);
        //m_state = State.Idle;
    }
    public void ShootAction()
    {
        var partM = lego.magazine.part as Magazine; 
        var partR = lego.receiver.part as Receiver; 
        var partS = lego.scope.part as Scope; 
        for (int a = 1; a <= partR.times; a++)
    {
        MultyFier();
        for (int i = 1; i <= partR.volume; i++)
        {
        Projectile bullet = Instantiate(bulletPrefab, m_muzzle.position, m_muzzle.rotation);

        Projectile projectileScript = bullet.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.maxDistance = partS.range;
            projectileScript.damage = lego.totalDamage; 
        }
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float randomSpreadY = UnityEngine.Random.Range(-partS.spread, partS.spread);
            Vector3 spreadDirection = Quaternion.Euler(0, randomSpreadY, 0) * m_muzzle.forward;
            rb.AddForce(spreadDirection.normalized * partR.force, ForceMode.Impulse);
        }
        }
    }
    }
}
