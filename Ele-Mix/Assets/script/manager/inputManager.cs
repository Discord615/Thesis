using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class inputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;
    private bool spacePressed = false;
    public static inputManager instance;

    private void Awake() {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inputManager");
        }
        instance = this;
    }
    public void movePressed(InputAction.CallbackContext context){
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

    public void SpacePressed(InputAction.CallbackContext context){
        if (context.performed)
        {
            Debug.Log("JUMP!");
            spacePressed = true;
        }
        else if (context.canceled)
        {
            spacePressed = false;
        }
    }

    public bool getSpacePressed(){
        bool result = spacePressed;
        spacePressed = false;
        return result;
    }

    public Vector2 getMovedPressed(){
        return moveDirection;
    }
}
