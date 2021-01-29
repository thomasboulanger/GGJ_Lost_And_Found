using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    PlayerControls inputActions;

    private bool balise_Input, ship_Input;

    Vector2 movementInput;

    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 3f;

    private float horizontal, vertical;

    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();

            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();

            inputActions.PlayerActions.Balise.performed += i => balise_Input = true;
            inputActions.PlayerActions.Ship.performed += i => ship_Input = true;
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;

        
    }

    private void FixedUpdate()
    {
        Movement(Time.deltaTime);
    }

    private void Movement(float delta)
    {
        #region Controller Joystick Clamp
        if (horizontal > 0.2f)
            horizontal = 1f;
        else if (horizontal < -0.2f)
            horizontal = -1f;
        else
            horizontal = 0f;

        if (vertical > 0.2f)
            vertical = 1f;
        else if (vertical < -0.2f)
            vertical = -1f;
        else
            vertical = 0f;
        #endregion

        Debug.Log(horizontal + " " + vertical);

        Vector2 move = new Vector2(horizontal, vertical);

        if (horizontal != 0 && vertical != 0)
        {
            move = .8f * move;
        }

        rb.velocity = move * speed;
    }
}
