using System.Collections;
using UnityEngine;

public class MeleePunch : MonoBehaviour
{
    public GameObject hitBox; // Ссылка на объект HitBox

    private void Awake()
    {
        hitBox.SetActive(false);
    }

    public void Attack()
    {
        hitBox.SetActive(true);
        StartCoroutine(DisableHitBoxAfterDelay(0.1f));
    }

    private IEnumerator DisableHitBoxAfterDelay(float delay)
    {
        // Ждем указанное время
        yield return new WaitForSeconds(delay);
        
        // Выключаем HitBox
        hitBox.SetActive(false);
    }
}
