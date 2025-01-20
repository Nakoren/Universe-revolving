using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

public class WeaponCageManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText; 
    [SerializeField] private WeaponManager weaponManager;

    private Weapon currentWeapon;

    private void OnEnable()
    {
        if (weaponManager != null)
        {
            Debug.Log("[WeaponUI]: Subscribing to OnWeaponChanged");
            weaponManager.OnWeaponChanged += UpdateWeaponUI;

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

        if (currentWeapon != null)
        {
            currentWeapon.OnAmmoChanged -= UpdateAmmoUI;
        }

        currentWeapon = newWeapon;

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