using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText; // Текст для отображения патронов
    [SerializeField] private WeaponManager weaponManager;
    //[SerializeField] private List<Weapon> weaponList;


    private void OnEnable()
    {

        weaponManager.OnWeaponChanged += UpdateWeaponUI;

            // Инициализация текущего оружия
            if (weaponManager.CurrentWeapon != null)
            {
                UpdateWeaponUI(weaponManager.CurrentWeapon);
                weaponManager.CurrentWeapon.OnAmmoChanged += UpdateAmmoUI;
            }
            else
            {
                ammoText.text = "No Weapon";
            }


    }

    private void OnDisable()
    {
        weaponManager.OnWeaponChanged -= UpdateWeaponUI;
        weaponManager.CurrentWeapon.OnAmmoChanged -= UpdateAmmoUI;
    }

    private void UpdateWeaponUI(Weapon newWeapon)
    {
        weaponManager.CurrentWeapon.OnAmmoChanged -= UpdateAmmoUI;

        weaponManager.CurrentWeapon = newWeapon;
        weaponManager.CurrentWeapon.OnAmmoChanged += UpdateAmmoUI;
        UpdateAmmoUI(weaponManager.CurrentWeapon.Ammo, weaponManager.CurrentWeapon.MaxAmmo);

    }

    private void UpdateAmmoUI(int newAmmo, int newMaxAmmo)
    {
        Debug.Log($"WeaponUI: Updating ammo to AAAAAAA{newAmmo}/{newMaxAmmo}");
        ammoText.text = $"{newAmmo}/{newMaxAmmo}";
    }
}