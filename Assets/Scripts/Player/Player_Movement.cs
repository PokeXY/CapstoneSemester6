using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

// Credit to BMo on youtube for the Unity Input System Tutorial
// "How to use Unity's New INPUT System EASILY" by BMo
// November 22, 2021.
// https://www.youtube.com/watch?v=HmXU4dZbaMw

public class Player_Movement : MonoBehaviour
{
    public string loadScene;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Camera cam;
    public PlayerInputAction pMovement;
    private AudioSource sfx;

    
    private float boostTimer;
    private bool boosting;

    //public float sizeUp = 1.4f;
    //private float sizeTimer;
    //private bool big;

    private InputAction move;
    private InputAction fire;
    Vector2 moveDirection = Vector2.zero;
    Vector2 mousePos;

    private void Awake()
    {
        pMovement = new PlayerInputAction();
        sfx = GetComponent<AudioSource>();

        moveSpeed = 5;
        boostTimer = 0;
        boosting = false;


        //sizeTimer = 0;
        //big = false;
    }

    private void OnEnable()
    {
        move = pMovement.Player.Move;
        move.Enable();
        //pMovement.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        //pMovement.Disable();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "SceneChange")
        {
            SceneManager.LoadScene(loadScene);
        }
    }


    // Start is called before the first frame update
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(boosting)
        {
            boostTimer += Time.deltaTime;
            if(boostTimer >= 3)
            {
                moveSpeed = 5;
                boostTimer = 0;
                boosting = false;
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
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        if (rb.velocity != Vector2.zero)
        {
            sfx.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "SpeedBoost")
        {
            boosting = true;
            moveSpeed = 10;
            Destroy(other.gameObject);
        }

        //if(other.tag == "SizeChange")
        //{
        //    big = true;
        //    other.transform.localScale *= sizeUp;
        //    Destroy(other.gameObject);

        //}
    }

}

    
