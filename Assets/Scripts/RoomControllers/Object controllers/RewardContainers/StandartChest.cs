using System.Collections;
using Unity.AppUI.UI;
using Unity.VisualScripting;
using UnityEngine;
using static PartsDB;

public class StandartChest : RewardContainer
{
    public PickupObject pickupObject;
    private float m_moveDistance = 3f;
    private float m_moveSpeed = 5f;
    private bool m_allreadiOpen = false;
    public GameObject cube;
    public override void Interact()
    {
        if (m_allreadiOpen == false)
        {
        if (onOpen != null) onOpen.Invoke();
        int randItemIndex = Random.Range(0, rewardItemDB.items.Count);
        PickupDrop(rewardItemDB.items[randItemIndex]);
        m_allreadiOpen = true;
        }
        
        Destroy(cube);
        //WaitDestroy();
    }
    private IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
    public void PickupDrop(Item item)
    {
        //What the actual fuck is this shit
        PartPickUpObject m_pickup = Instantiate(pickupObject, transform.position, transform.rotation);
        m_pickup.GetPart(item);
        MoveRandomly(m_pickup);
    }
    public void MoveRandomly(PickupObject objectToMove)
    {
        if (objectToMove != null)
        {
            // Генерируем случайный угол в радианах
            float randomAngle = Random.Range(0f, 360f);
            
            // Вычисляем смещение по X и Z
            float xOffset = Mathf.Cos(randomAngle * Mathf.Deg2Rad) * m_moveDistance;
            float zOffset = Mathf.Sin(randomAngle * Mathf.Deg2Rad) * m_moveDistance;

            // Рассчитываем новую целевую позицию, сохраняя значение Y
            Vector3 targetPosition = new Vector3(objectToMove.transform.position.x + xOffset,
                                          objectToMove.transform.position.y,
                                          objectToMove.transform.position.z + zOffset);

            // Запускаем корутину для плавного перемещения
            StartCoroutine(MoveToTarget(objectToMove, targetPosition));
        }
        else
        {
            Debug.LogWarning("Объект для перемещения не назначен!");
        }
    }
    private IEnumerator MoveToTarget(PickupObject objectToMove, Vector3 targetPosition)
    {
        Vector3 startPosition = objectToMove.transform.position; // Начальная позиция
        float journeyLength = Vector3.Distance(startPosition, targetPosition); // Длина пути
        float startTime = Time.time; // Время начала

        while (Vector3.Distance(objectToMove.transform.position, targetPosition) > 0.01f)
        {
            // Вычисляем, сколько времени прошло
            float distCovered = (Time.time - startTime) * m_moveSpeed;
            // Находим интерполяцию между начальной и целевой позицией
            float fractionOfJourney = distCovered / journeyLength;

            // Плавно перемещаем объект
            objectToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

            yield return null; // Ждем до следующего кадра
        }

        // Устанавливаем объект точно на целевую позицию в конце
        objectToMove.transform.position = targetPosition;
        Debug.Log("Объект достиг целевой позиции: " + targetPosition);
    }
}
