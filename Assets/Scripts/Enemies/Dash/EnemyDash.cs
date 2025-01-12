using System.Collections;
using UnityEngine;

public class EnemyDash : MonoBehaviour
{
    public enum DashLogicType
    {
        Dodge,
        StopAndDash
    }

    [Header("Dash Settings")]
    [SerializeField] private DashLogicType dashLogic = DashLogicType.Dodge;
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private float dashInterval = 5f;
    [SerializeField] private float dashDistance = 3f;

    [SerializeField] private Transform target;
    private bool isDashing = false;
    public bool IsDashing => isDashing;
    private Coroutine dashCoroutine;
    private IDashLogic currentLogic;

    private Vector3 previousPosition;

    private void Awake()
    {
        previousPosition = transform.position;
        InitializeDashLogic();
        StartCoroutine(DashLogic());
    }

    private void InitializeDashLogic()
    {
        switch (dashLogic)
        {
            case DashLogicType.Dodge:
                currentLogic = new DodgeDashLogic(dashInterval);
                break;
            case DashLogicType.StopAndDash:
                currentLogic = new StopAndDashLogic(dashDistance);
                break;
        }
    }

    private IEnumerator DashLogic()
    {
        while (true)
        {
            if (target != null && currentLogic != null && !isDashing)
            {
                currentLogic.ExecuteDash(this, target);
            }
            yield return null;
        }
    }

    public void StartDash(Vector3 direction)
    {
        if (isDashing) return;

        isDashing = true;
        dashCoroutine = StartCoroutine(DashCoroutine(direction));
    }

    private IEnumerator DashCoroutine(Vector3 direction)
    {
        float elapsedTime = 0f;

        while (elapsedTime < dashDuration)
        {
            transform.position += direction * dashSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }

}



