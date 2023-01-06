using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public Rigidbody2D rb;
    private Vector2 vel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        vel = movement.normalized * speed;
    }

    // Physics related update, only updates when something with physics runs
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + vel * Time.fixedDeltaTime);

    }

}
