using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponManager : MonoBehaviour
{
    private readonly List<Weapon> m_weapons = new List<Weapon>();
    private Weapon m_currentWeapon;
    public Weapon CurrentWeapon=> m_currentWeapon;

    public event System.Action OnWeaponChanged;
   // public event System.Action onShoot;
	//public event System.Action onReload;
   

    private void Awake()
    {
        GetComponentsInChildren(true, m_weapons);
        m_weapons.ForEach(x => x.gameObject.SetActive(false));

        SetActiveWeapon(0);
    }

   private void Start()
    {
       
        SetActiveWeapon(0);
    }

    public void StartFire()
    {
        //Debug.Log($"[WeaponManager]: StartFire");
        if (m_currentWeapon)
        {
            m_currentWeapon.StartFire();
        }
    }

    public void StopFire()
    {
        //Debug.Log($"[WeaponManager]: StopFire");
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
        //Debug.Log($"[WeaponManager]: NextWeapon");
        int index = m_weapons.IndexOf(m_currentWeapon);
        if (index >= 0)
        {
            SetActiveWeapon(++index % m_weapons.Count);
        }
    }

    public void SetActiveWeapon(int index)
    {
        //Debug.Log($"[WeaponManager]: SetActiveWeapon({index})");
        if (m_currentWeapon)
        {
            m_currentWeapon.onShoot -= OnCurWeaponShoot;
			//m_currentWeapon.onReload -= OnCurWeaponReload;
            m_currentWeapon.gameObject.SetActive(false);
            m_currentWeapon = null;
        }

        if (index >= 0 && index < m_weapons.Count)
        {
            m_currentWeapon = m_weapons[index];
            m_currentWeapon.gameObject.SetActive(true);
            m_currentWeapon.onShoot += OnCurWeaponShoot;
			//m_currentWeapon.onReload += OnCurWeaponReload;
            Debug.Log($"[WeaponManager]: SetActiveWeapon({m_currentWeapon.name})");
            
        }
         OnWeaponChanged?.Invoke();
    }

    private void OnCurWeaponReload()
	{
		//onReload?.Invoke();
	}

	private void OnCurWeaponShoot()
	{
		//onShoot?.Invoke();
	}
}
