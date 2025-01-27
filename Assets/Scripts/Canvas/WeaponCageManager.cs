using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

public class WeaponCageManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private WeaponManager m_weaponManager;

    private Weapon m_currentWeapon;

    public void Init(WeaponManager weaponManager)
    {
        m_weaponManager = weaponManager;
    }

    private void OnEnable()
    {

        if (m_weaponManager)
        {
            m_weaponManager.OnWeaponChanged += OnWeaponChanged;
            m_weaponManager.onShoot += OnShoot;
            m_weaponManager.onReload += OnShoot;
            OnWeaponChanged();
        }

    }

    private void OnDisable()
    {
        if (m_weaponManager)
        {
            m_weaponManager.OnWeaponChanged -= OnWeaponChanged;
            m_weaponManager.onShoot -= OnShoot;
            m_weaponManager.onReload -= OnShoot;
        }
    }


    private void OnShoot()
    {
        RefreshBulletInfo(m_weaponManager.CurrentWeapon);
    }
    private void OnWeaponChanged()
    {
        var curWeapon = m_weaponManager.CurrentWeapon;

        if (curWeapon)
        {

            RefreshBulletInfo(curWeapon);
        }

        
    }

    private void RefreshBulletInfo(Weapon weapon)
    {
        if (weapon)
        {
            ammoText.text = $"{weapon.Ammo}/{weapon.MaxAmmo}";
        }

        
    }

}