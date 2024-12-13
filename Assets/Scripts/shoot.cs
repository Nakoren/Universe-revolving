using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class shoot : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;
    public float shootForce;
    public float spread;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        Shoot();
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        targetPoint.y = spawnBullet.position.y;

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float x = Random.Range(-spread, spread);
        float z = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, 0, z);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce,ForceMode.Impulse);
    }

}