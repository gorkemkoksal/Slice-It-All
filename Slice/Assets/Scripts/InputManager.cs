using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Action onAnyTouch;
    public void Touch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onAnyTouch?.Invoke();
            print("touch");
        }
    }
}
