using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponManager : MonoBehaviour
{
    private readonly List<Weapon> m_weapons = new List<Weapon>();
    private Weapon m_currentWeapon;

    public event Action<Weapon> OnWeaponChanged;




    public Weapon CurrentWeapon
    {
        get => m_currentWeapon;
        set
        {
            m_currentWeapon = value;
            OnWeaponChanged?.Invoke(m_currentWeapon);
        }
    }


    private void Awake()
    {
        GetComponentsInChildren(true, m_weapons);
        m_weapons.ForEach(x => x.gameObject.SetActive(false));

        SetActiveWeapon(0);
    }

    public void StartFire()
    {
        Debug.Log($"[WeaponManager]: StartFire");
        if (m_currentWeapon)
        {
            m_currentWeapon.StartFire();
        }
    }

    public void StopFire()
    {
        Debug.Log($"[WeaponManager]: StopFire");
        if (m_currentWeapon)
        {
            m_currentWeapon.StopFire();
        }
    }
    public void Reload()
    {
        m_currentWeapon.Reload();
    }

    public void NextWeapon()
    {
        Debug.Log($"[WeaponManager]: NextWeapon");
        int index = m_weapons.IndexOf(m_currentWeapon);
        if (index >= 0)
        {
            SetActiveWeapon(++index % m_weapons.Count);
        }
    }

    public void SetActiveWeapon(int index)
    {
        Debug.Log($"[WeaponManager]: SetActiveWeapon({index})");
        if (m_currentWeapon)
        {
            m_currentWeapon.gameObject.SetActive(false);
            m_currentWeapon = null;
        }

        if (index >= 0 && index < m_weapons.Count)
        {
            m_currentWeapon = m_weapons[index];
            m_currentWeapon.gameObject.SetActive(true);
            Debug.Log($"[WeaponManager]: SetActiveWeapon({m_currentWeapon.name})");
            if (OnWeaponChanged != null)
            {
                Debug.Log($"[WeaponManager]: Invoking OnWeaponChanged with {m_currentWeapon.name}");
                OnWeaponChanged.Invoke(m_currentWeapon);
            }
        }
    }
}
