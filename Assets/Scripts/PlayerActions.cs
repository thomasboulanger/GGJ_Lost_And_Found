using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    PlayerControls inputActions;

    StepsSystem stepsSystem;

    [HideInInspector]
    public bool beacon_Input, escape_Input;

    Vector2 movementInput;

    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 3f;

    [HideInInspector]
    public float horizontal, vertical;

    [SerializeField]
    private GameObject beacon;

    [SerializeField]
    private float distanceBeacon = 5f;

    List<GameObject> beaconsList = new List<GameObject>();

    [SerializeField]
    private Animator animator;

    private bool isMoving = false;

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();

            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();

            inputActions.PlayerActions.Beacon.performed += i => beacon_Input = true;

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
        stepsSystem = GetComponent<StepsSystem>();
    }

    private void Update()
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        animator.SetBool("isMoving", isMoving);

        /*if ((horizontal != 0f || vertical != 0f) && transform.position != ScrollUV.singleton.lastPlayerPos)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }*/
       
        Rotation();

        BeaconManager();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void LateUpdate()
    {
        beacon_Input = false;
        escape_Input = false;
    }

    private void Rotation()
    {
        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);
        }

        if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z);
        }
    }

    private void Movement()
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

    private int index = 2;

    private void BeaconManager()
    {
        bool spawnableBeacon = true;

        if (beaconsList.Count == stepsSystem.nbSteps)
            spawnableBeacon = false;

        if (beaconsList.Count > 0)
        {
            foreach(GameObject oneBeacon in beaconsList)
            {
                float distance = Vector2.Distance(transform.position, oneBeacon.transform.position);

                if (distance < distanceBeacon)
                {
                    spawnableBeacon = false;

                    if (beacon_Input && oneBeacon == beaconsList[beaconsList.Count - 1])
                    {
                        Destroy(oneBeacon);
                        beaconsList.Remove(oneBeacon);

                        index = stepsSystem.RemoveStep(index);
                    }  
                }
            }

            if (beacon_Input && spawnableBeacon && stepsSystem.nbSteps-1 != beaconsList.Count)
            {
                beaconsList.Add(Instantiate(beacon, transform.position, Quaternion.identity));

                index = stepsSystem.AddStep(index);
            }
            else if (beacon_Input && stepsSystem.nbSteps-1 == beaconsList.Count)
            {
                index = stepsSystem.AddStep(index);
            }
        }
        else if (beacon_Input)
        {
            beaconsList.Add(Instantiate(beacon, transform.position, Quaternion.identity));

            index = stepsSystem.AddStep(1);
        }
    }
}