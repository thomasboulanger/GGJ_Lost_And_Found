using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2(horizontal, vertical);
        if (Mathf.Abs(horizontal) > 0 && Mathf.Abs(vertical) > 0)
        {
            move = .7f * move;
        }
        rb.AddForce(move * speed * Time.deltaTime);


    }
}
