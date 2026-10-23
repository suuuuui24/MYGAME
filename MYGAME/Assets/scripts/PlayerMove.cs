using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector2 inputDirection;
    private bool canControl = false;

    void Update()
    {
        // 操作できないキャラクターは移動しない
        if (!canControl)
        {
            return;
        }

        // 入力方向に移動する（地面はX-Z平面）
        Vector3 direction = new Vector3(
            inputDirection.x,
            0,
            inputDirection.y
        );

        transform.position += direction * speed * Time.deltaTime;
    }

    // Input Systemから移動入力を受け取る
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!canControl || context.canceled)
        {
            inputDirection = Vector2.zero;
            return;
        }

        inputDirection = context.ReadValue<Vector2>();
    }

    // キャラクターの操作を切り替える
    public void ChangeControl(bool isControl)
    {
        canControl = isControl;

        if (!canControl)
        {
            inputDirection = Vector2.zero;
        }
    }
}