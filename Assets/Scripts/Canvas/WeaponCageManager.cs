using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

public class WeaponCageManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText; // Текст для отображения патронов
    [SerializeField] private WeaponManager weaponManager;

    private Weapon currentWeapon;

    private void OnEnable()
    {
        if (weaponManager != null)
        {
            // Подписка на событие смены оружия
            Debug.Log("[WeaponUI]: Subscribing to OnWeaponChanged");
            weaponManager.OnWeaponChanged += UpdateWeaponUI;

            // Инициализация текущего оружия
            if (weaponManager.CurrentWeapon != null)
            {
                SetCurrentWeapon(weaponManager.CurrentWeapon);
            }
            else
            {
                ammoText.text = "No Weapon";
            }
        }
    }

    private void OnDisable()
    {
        if (weaponManager != null)
        {
            weaponManager.OnWeaponChanged -= UpdateWeaponUI;

            // Отписываемся от текущего оружия
            if (currentWeapon != null)
            {
                currentWeapon.OnAmmoChanged -= UpdateAmmoUI;
            }
        }
    }

    private void UpdateWeaponUI(Weapon newWeapon)
    {
        Debug.Log($"[WeaponUI]: Weapon changed to {newWeapon?.name ?? "None"}");
        SetCurrentWeapon(newWeapon);

    }

    private void SetCurrentWeapon(Weapon newWeapon)
    {
        // Отписываемся от события предыдущего оружия
        if (currentWeapon != null)
        {
            currentWeapon.OnAmmoChanged -= UpdateAmmoUI;
        }

        // Обновляем ссылку на новое оружие
        currentWeapon = newWeapon;

        // Подписываемся на новое оружие
        if (currentWeapon != null)
        {
            currentWeapon.OnAmmoChanged += UpdateAmmoUI;
            UpdateAmmoUI(currentWeapon.Ammo, currentWeapon.MaxAmmo);
        }
        else
        {
            ammoText.text = "No Weapon";
        }
    }

    private void UpdateAmmoUI(int newAmmo, int newMaxAmmo)
    {
        Debug.Log($"WeaponUI: Updating ammo to {newAmmo}/{newMaxAmmo}");
        ammoText.text = $"{newAmmo}/{newMaxAmmo}";
    }
}