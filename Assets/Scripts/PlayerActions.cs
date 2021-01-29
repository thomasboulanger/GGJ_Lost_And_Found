using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    PlayerControls inputActions;

    public bool beacon_Input, ship_Input, escape_Input;

    Vector2 movementInput;

    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 3f;

    private float horizontal, vertical;

    [SerializeField]
    private GameObject beacon;

    [SerializeField]
    private float distanceBeacon = 5f;

    List<GameObject> beaconsList = new List<GameObject>();

    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();

            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();

            inputActions.PlayerActions.Beacon.performed += i => beacon_Input = true;
            inputActions.PlayerActions.Ship.performed += i => ship_Input = true;

            inputActions.PlayerMenu.Pause.performed += i => escape_Input = true;
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

        BeaconManager();
    }

    private void FixedUpdate()
    {
        Movement(Time.deltaTime);
    }

    private void LateUpdate()
    {
        beacon_Input = false;
        ship_Input = false;
        escape_Input = false;
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

        Vector2 move = new Vector2(horizontal, vertical);

        if (horizontal != 0 && vertical != 0)
        {
            move = .8f * move;
        }

        rb.velocity = move * speed;
    }

    private void BeaconManager()
    {
        bool spawnableBeacon = true;

        if (beaconsList.Count > 0)
        {
            foreach(GameObject oneBeacon in beaconsList)
            {
                if (oneBeacon != null)
                {
                    float distance = Vector2.Distance(transform.position, oneBeacon.transform.position);

                    if (distance < distanceBeacon)
                    {
                        spawnableBeacon = false;

                        if (beacon_Input)
                            Destroy(oneBeacon);
                    }
                }
            }

            if (beacon_Input && spawnableBeacon)
                beaconsList.Add(Instantiate(beacon, transform.position, Quaternion.identity));
        }
        else
        {
            if (beacon_Input)
                beaconsList.Add(Instantiate(beacon, transform.position, Quaternion.identity));
        }
    }
}