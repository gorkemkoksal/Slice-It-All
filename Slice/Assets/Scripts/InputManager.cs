using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Action OnAnyTouch;
    public void Touch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnAnyTouch?.Invoke();
        }
    }
}
