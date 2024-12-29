using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int existenceTime = 3;
    public System.Action onDestroy;

    public void Awake()
    {
        StartCoroutine(destroyCoroutine(existenceTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided");
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
