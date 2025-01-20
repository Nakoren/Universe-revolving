using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Slider hpStat; // Ссылка на слайдер здоровья
    [SerializeField] private GameObject canvas; // Ссылка на Canvas врага


    private Health health; // Ссылка на компонент здоровья

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        if (health != null)
        {
            health.onZeroHealth += OnZeroHealth; 
        }
    }

    private void OnDisable()
    {
        if (health != null)
        {
            health.onZeroHealth -= OnZeroHealth;
        }
    }

    private void Start()
    {
        if (hpStat != null && health != null)
        {
            hpStat.maxValue = health.GetMaxHealth(); 
            hpStat.value = health.GetCurrentHealth(); 
        }
    }

    private void Update()
    {
        if (canvas != null && Camera.main != null)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }

        if (hpStat != null && health != null)
        {
            hpStat.value = health.GetCurrentHealth();
        }
    }

    private void OnZeroHealth()
    {
        Debug.Log("Enemy has died.");
    }
}
