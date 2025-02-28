using System.Collections;
using Unity.AppUI.UI;
using Unity.VisualScripting;
using UnityEngine;
using static PartsDB;

public class StandartChest : RewardContainer
{
    public PartPickUpObject pickupObject;
    public MoneyPickupObject moneyPickupObject;
    private float m_moveDistance = 4f;
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
        int randomMoneyValue = Random.Range(19, 19);
        MoneyDrop(randomMoneyValue);
        m_allreadiOpen = true;
        }
    }

    private void MoneyDrop(int value)
    {
        int allValue = value * 25;
        // / без остатка
        // % остаток 
        int bigValue = allValue / 100;
        int bigOstatok = allValue % 100;
        for (int i = 0 ; i < bigValue ; i++)
        {
            MoneyPickupObject m_Bigcoin = Instantiate(moneyPickupObject, transform.position, transform.rotation);
            m_Bigcoin.transform.localScale = new Vector3(3f, 3f, 3f);
            MoveRandomly(m_Bigcoin);
            m_Bigcoin.SetValue(100);
        }

        int mediumValue = bigOstatok / 50;
        int mediumOstatok = bigOstatok % 50;
        for (int i = 0 ; i < mediumValue ; i++)
        {
            MoneyPickupObject m_Mediumcoin = Instantiate(moneyPickupObject, transform.position, transform.rotation);
            m_Mediumcoin.transform.localScale = new Vector3(2f, 2f, 2f);
            MoveRandomly(m_Mediumcoin);
            m_Mediumcoin.SetValue(50);
        }

        int miniValue = mediumOstatok % 25;
        for (int i = 0 ; i < miniValue ; i++)
        {
            MoneyPickupObject m_Minicoin = Instantiate(moneyPickupObject, transform.position, transform.rotation);
            m_Minicoin.transform.localScale = new Vector3(1f, 1f, 1f);
            MoveRandomly(m_Minicoin);
            m_Minicoin.SetValue(25);
        }
        
        
        
        
        if (value == 8)
        {
            MoneyPickupObject m_Bigcoin = Instantiate(moneyPickupObject, transform.position, transform.rotation);
            m_Bigcoin.transform.localScale = new Vector3(3f, 3f, 3f);
            MoveRandomly(m_Bigcoin);
            //m_Bigcoin.SetValue(bigValue);
        }
        

        int shtuki = value * 25;
    }

    public void PickupDrop(Item item)
    {
        //What the actual fuck is this shit
        PartPickUpObject m_pickup = Instantiate(pickupObject, transform.position, transform.rotation);
        m_pickup.GetPart(item);
        MoveRandomly(m_pickup);
    }
    public void MoveRandomly(PickUpObject objectToMove)
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
    private IEnumerator MoveToTarget(PickUpObject objectToMove, Vector3 targetPosition)
    {
        Vector3 startPosition = objectToMove.transform.position; // Начальная позиция
        float journeyLength = Vector3.Distance(startPosition, targetPosition); // Длина пути
        float startTime = Time.time; // Время начала

        float targetY = targetPosition.y;

        while (Vector3.Distance(objectToMove.transform.position, targetPosition) > 0.01f)
        {
            // Вычисляем, сколько времени прошло
            float distCovered = (Time.time - startTime) * m_moveSpeed;
            // Находим интерполяцию между начальной и целевой позицией
            float fractionOfJourney = distCovered / journeyLength;

            targetPosition.y = targetY + Mathf.Sin(Mathf.PI * fractionOfJourney) * 3f;

            // Плавно перемещаем объект
            objectToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

            yield return null; // Ждем до следующего кадра
        }

        // Устанавливаем объект точно на целевую позицию в конце
        objectToMove.transform.position = targetPosition;
        Debug.Log("Объект достиг целевой позиции: " + targetPosition);
    }
}
