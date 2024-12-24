using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnBullet;
    public float shootForce;
    public ScopeDataSO scopeData;
    public ReceiverDataSO receiverData;
    public MagazineDataSO magazineData;
    private Coroutine m_fireCoroutine;
    private int ammo = 0;

    public void Reload()
    {
        ammo = magazineData.cage;
    }
    public void StartReload()
    {
        m_fireCoroutine = StartCoroutine(ReloadDelay());
        Reload();
    }

    private IEnumerator ReloadDelay()
    {
        Debug.Log($"Reload start");
        do
        {
            yield return new WaitForSeconds(receiverData.shootDelay);
        }
        while(true);
    }

    public void StopReload()
    {
        if (m_fireCoroutine != null)
        {
            StopCoroutine(m_fireCoroutine);
            m_fireCoroutine = null;
        }
    }

    public void ShootToTarget(Vector3 target)
    {
        if (ammo > 0)
        {
        target.y = spawnBullet.position.y;

        Vector3 dirWithoutSpread = target - spawnBullet.position;

        float x = Random.Range(-scopeData.spread, scopeData.spread);
        float z = Random.Range(-scopeData.spread, scopeData.spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, 0, z);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);

        ammo = ammo - 1;
        Debug.Log($"ammo - {ammo}");
        }
        else
        {
            Debug.Log($"ammo - pusto {ammo}");
        }
    }
}
