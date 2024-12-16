using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnBullet;
    public float shootForce;
    public float spread;


    public void ShootToDirection(Vector3 direction)
    {
        
    }

    public void ShootToTarget(Vector3 target)
    {
        
        target.y = spawnBullet.position.y;

        Vector3 dirWithoutSpread = target - spawnBullet.position;

        float x = Random.Range(-spread, spread);
        float z = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, 0, z);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }

    public void shootForward()
    {

    }
}