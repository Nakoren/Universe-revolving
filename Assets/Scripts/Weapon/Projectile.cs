using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public int existenceTime = 3;
    [SerializeField] public System.Action onDestroy;
    [SerializeField] public int Damage = 0;

    public void Awake()
    {
        StartCoroutine(destroyCoroutine(existenceTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(onDestroy != null)
        {
            onDestroy.Invoke();
        }
        Destroy(gameObject);
    }

    private IEnumerator destroyCoroutine(int destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
