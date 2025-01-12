using System.Collections;
using UnityEngine;

public interface IDashLogic
{
    void ExecuteDash(EnemyDash context, Transform target);
}

// Логика уворачивания
public class DodgeDashLogic : IDashLogic
{
    private float dashInterval;
    private bool isWaiting = false;

    public DodgeDashLogic(float dashInterval)
    {
        this.dashInterval = dashInterval;
    }

    public void ExecuteDash(EnemyDash context, Transform target)
    {
        if (!context.IsDashing && !isWaiting) // Проверяем состояние рывка и ожидания
        {
            context.StartCoroutine(ExecuteDodge(context, target));
        }
    }

    private IEnumerator ExecuteDodge(EnemyDash context, Transform target)
    {
        isWaiting = true; // Включаем задержку
        yield return new WaitForSeconds(dashInterval);

        Vector3 toTarget = (target.position - context.transform.position).normalized;
        Vector3 dodgeDirection = Random.value > 0.5f
            ? Vector3.Cross(toTarget, Vector3.up)
            : -Vector3.Cross(toTarget, Vector3.up);

        context.StartDash(dodgeDirection);
        isWaiting = false; // Завершаем задержку
    }
}

// Логика рывка при остановке
public class StopAndDashLogic : IDashLogic
{
    private float stopDistance;

    public StopAndDashLogic(float stopDistance)
    {
        this.stopDistance = stopDistance;
    }

    public void ExecuteDash(EnemyDash context, Transform target)
    {
        if (target == null || context.IsDashing)
            return;

        float distanceToTarget = Vector3.Distance(context.transform.position, target.position);

        // Проверяем, находится ли враг в пределах заданного расстояния
        if (distanceToTarget <= stopDistance)
        {
            Vector3 dashDirection = (target.position - context.transform.position).normalized;
            context.StartDash(dashDirection);
        }
    }
}
