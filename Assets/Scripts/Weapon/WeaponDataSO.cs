using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class WeaponDataSO : ScriptableObject
{
    public float delay = 1f;
    public float power = 15f;
    public GameObject bulletPrefab;
    public GameObject prefab;
    public Sprite icon;
    }
