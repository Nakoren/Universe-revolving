using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public float delay { private set; get; } = 1f;
    public int cage = 10;
    public float power = 15f;
    public GameObject bulletPrefab;
    public GameObject prefab;
    public Sprite icon;
    }
