using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private Vector2 currentInput;
    [SerializeField] private Rigidbody PlayerBody;
    
    private void Awake()
    {
        PlayerBody = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        MoveUpdate();
    }

    public void MoveUpdate()
    {
        float currentspeed = moveSpeed * Time.deltaTime;
        Vector3 directionVector = transform.forward * currentInput.y + transform.right * currentInput.x;
        directionVector *= currentspeed;

        directionVector.y = PlayerBody.linearVelocity.y;

        PlayerBody.linearVelocity = directionVector;

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            currentInput = context.ReadValue<Vector3>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            currentInput = Vector3.zero;
        }
    }
}
