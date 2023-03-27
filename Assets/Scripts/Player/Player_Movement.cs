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


    private InputAction move;
    private InputAction fire;
    Vector2 moveDirection = Vector2.zero;
    Vector2 mousePos;

    private void Awake()
    {
        pMovement = new PlayerInputAction();
        sfx = GetComponent<AudioSource>();
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

}
