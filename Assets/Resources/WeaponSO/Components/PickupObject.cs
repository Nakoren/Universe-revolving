using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject scopePrefab; // Префаб для объекта Scope
    public GameObject weapon; // Ссылка на объект Weapon
    public PickupObject pickupObjectPrefab; // Префаб для объекта PickupObjectInfo
    public Transform player; // Ссылка на игрока для позиционирования


    public void GetInfo(GameObject info)
    {

        scopePrefab = info;
    }


    void Update()
    {
        // Проверяем, была ли нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч из камеры
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, попал ли луч на объект PickupObject
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // Проверяем, есть ли уже дочерний объект с компонентом ScopeElement
                    ScopeElement existingScope = weapon.GetComponentInChildren<ScopeElement>();
                    if (existingScope != null)
                    {
                        // Создаем новый объект PickupObjectInfo рядом с игроком
                        PickupObject pickupObject_new = Instantiate(pickupObjectPrefab, player.position + Vector3.forward, Quaternion.identity);
                        pickupObject_new.GetInfo(existingScope.gameObject);

                        // Удаляем старый объект Scope
                        Destroy(existingScope.gameObject);
                    }

                    // Создаем новый объект Scope как дочерний объект Weapon
                    GameObject scope = Instantiate(scopePrefab, weapon.transform);
                    scope.transform.localPosition = Vector3.zero; // Устанавливаем позицию объекта в (0, 0, 0) относительно Weapon

                    // Удаляем объект PickupObject
                    Destroy(gameObject);
                }
            }
        }
    }
}
