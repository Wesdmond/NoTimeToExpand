using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public PlayerInput playerInput;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector3 rawInputMovement;

    [Range(0.001f, 0.1f)]
    public float movementSpeed;

    bool down;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();

        animator.SetFloat("Horizontal speed", Mathf.Abs(inputMovement.x));
        animator.SetFloat("Vertical speed", Mathf.Abs(inputMovement.y));

        if (inputMovement.y < 0)
            down = true;
        else if (inputMovement.y >= 0)
            down = false;

        animator.SetBool("Down", down);

        if (inputMovement.x < 0)
            spriteRenderer.flipX = false;
        else if (inputMovement.x > 0)
            spriteRenderer.flipX = true;

        rawInputMovement = new Vector3(inputMovement.x, inputMovement.y, inputMovement.y);
    }

    public void OnLeftMouse()
    {
        Debug.Log("Left Mouse");
    }

    public void OnRightMouse(InputAction.CallbackContext value)
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += rawInputMovement * movementSpeed * 700 * Time.deltaTime;
    }
}
