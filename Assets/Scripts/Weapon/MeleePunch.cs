using System.Collections;
using UnityEngine;

public class MeleePunch : MonoBehaviour
{
    public int existenceTime = 3;
    public System.Action onDestroy;
    public void Awake()
    {
        StartCoroutine(destroyCoroutine(existenceTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private IEnumerator destroyCoroutine(int destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
