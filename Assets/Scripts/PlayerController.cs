using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public PlayerInput playerInput;
    Vector3 rawInputMovement;

    [Range(0.001f, 0.1f)]
    public float movementSpeed;

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void OnLeftMouse(InputAction.CallbackContext value)
    {

    }

    public void OnRightMouse(InputAction.CallbackContext value)
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rawInputMovement * movementSpeed);
        gameObject.transform.position = gameObject.transform.position + rawInputMovement * movementSpeed;
    }
}
