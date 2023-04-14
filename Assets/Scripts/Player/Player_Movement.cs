using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using UnityEngine.Animations;

// Credit to BMo on youtube for the Unity Input System Tutorial
// "How to use Unity's New INPUT System EASILY" by BMo
// November 22, 2021.
// https://www.youtube.com/watch?v=HmXU4dZbaMw

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Camera cam;
    public PlayerInputAction pMovement;
    private AudioSource sfx;
    public Animator playerAnimator;

    private float boostTimer;
    private bool boosting;
    private float dashTimer;
    private bool isDashing;
    private float dashCooldown;

    private InputAction move;
    private InputAction dash;
    private InputAction fire;
    Vector2 moveDirection = Vector2.zero;
    Vector2 mousePos;

    private void Awake()
    {
        pMovement = new PlayerInputAction();
        sfx = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();

        moveSpeed = 9;
        dashTimer = 0;
        isDashing = false;

        boostTimer = 0;
        boosting = false;

        //sizeTimer = 0;
        //big = false;
    }

    private void OnEnable()
    {
        dash = pMovement.Player.Dash;
        dash.Enable();
        dash.performed += Dash;
        move = pMovement.Player.Move;
        move.Enable();
        //pMovement.Enable();
    }

    private void OnDisable()
    {
        dash.Disable();
        move.Disable();
        //pMovement.Disable();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedBoost")
        {
            boosting = true;
            moveSpeed = 15;
            Destroy(other.gameObject);
        }

        //if(other.tag == "SizeChange")
        //{
        //    big = true;
        //    other.transform.localScale *= sizeUp;
        //    Destroy(other.gameObject);

        //}
    }


    // Start is called before the first frame update
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 3)
            {
                moveSpeed = 9;
                boostTimer = 0;
                boosting = false;
            }
        }

        if (isDashing)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer >= 0.2)
            {
                moveSpeed = 9;
                dashTimer = 0;
                isDashing = false;
            }
        }

        //if(big)
        //{
        //    sizeTimer += Time.deltaTime;
        //    if(sizeTimer >= 3)
        //    {
        //        player.transform.localScale;
        //        sizeTimer = 0;
        //        big = false;
        //    }
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lo  okDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;


        if (rb.velocity != Vector2.zero)
        {
            //sfx.Play();
            playerAnimator.SetFloat("xAxis", moveDirection.x);
            playerAnimator.SetFloat("yAxis", moveDirection.y);
        }
    }

    private void Dash(InputAction.CallbackContext context)
    {
        isDashing = true;
        moveSpeed = 35;
    }

}
