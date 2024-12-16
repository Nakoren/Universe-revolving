using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{

    public int speed;

    private CharacterController m_charController;
    private void Awake()
    {
        m_charController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 moveDir, Vector3 baseDirection)
    {
        if (!(moveDir.magnitude > 0))
        {
            m_charController.SimpleMove(new Vector3());
            return;
        }

        float baseMovementAngle = Mathf.Atan2(moveDir.y, moveDir.x);
        float newAngle = baseMovementAngle - Mathf.Atan2(baseDirection.x, baseDirection.z);
        //Debug.Log(baseMovementAngle + " " + newAngle);
        float x = Mathf.Cos(newAngle);
        float y = Mathf.Sin(newAngle);

        Vector3 moveDirV3 = new Vector3(x, 0f, y);

        m_charController.SimpleMove(moveDirV3 * speed);
    }

    public void RotateToPosition(Vector3 position)
    {
        transform.LookAt(position);
        Quaternion newRotation = new Quaternion(0f, transform.rotation.y, 0f, transform.rotation.w);
        transform.rotation = newRotation;
    }
}
