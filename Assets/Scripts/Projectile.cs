using UnityEngine;

public class Projectile : MonoBehaviour
{
    public System.Action onDestroy;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if(onDestroy != null)
        {
            onDestroy.Invoke();
        }
        Destroy(gameObject);
    }
}
