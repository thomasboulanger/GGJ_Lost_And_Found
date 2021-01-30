using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUVMain : MonoBehaviour
{
    private PlayerControls inputActions;

    private Vector2 mouseMovementInput;

    private float mouseX, mouseY;

    [SerializeField]
    private float bgSpeed = 0.0001f;

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();

            inputActions.PlayerMovement.MouseMovement.performed += inputActions => mouseMovementInput = inputActions.ReadValue<Vector2>();
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        mouseX = mouseMovementInput.x;
        mouseY = mouseMovementInput.y;

        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        if (mouseX > 0.1f)
            offset.x += bgSpeed;
        else if (mouseX < -0.1f)
            offset.x -= bgSpeed;

        if (mouseY > 0.1f)
            offset.y += bgSpeed;
        else if (mouseY < -0.1f)
            offset.y -= bgSpeed;

        mat.mainTextureOffset = offset;
    }
}
