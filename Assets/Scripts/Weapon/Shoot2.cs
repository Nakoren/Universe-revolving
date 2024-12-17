using System.Collections;
using UnityEngine;

public class Shoot2 : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnBullet;
    public float shootForce;
    public ScopeDataSO scopeData;
    public ReceiverDataSO receiverData;
    public MagazineDataSO magazineData;
    private Coroutine m_fireCoroutine;


    public void StartFire()
    {
        m_fireCoroutine = StartCoroutine(FireDelay());
    }

    private IEnumerator FireDelay()
    {
        do
        {
            yield return new WaitForSeconds(receiverData.shootDelay);
        }
        while(true);
    }

    public void StopFire()
    {
        if (m_fireCoroutine != null)
        {
            StopCoroutine(m_fireCoroutine);
            m_fireCoroutine = null;
        }
    }

    public void ShootToTarget(Vector3 target)
    {
        FireDelay();
        target.y = spawnBullet.position.y;

        Vector3 dirWithoutSpread = target - spawnBullet.position;

        float x = Random.Range(-scopeData.spread, scopeData.spread);
        float z = Random.Range(-scopeData.spread, scopeData.spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, 0, z);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }
}
