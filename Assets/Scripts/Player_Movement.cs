using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Credit to BMo on youtube for the Unity Input System Tutorial
// "How to use Unity's New INPUT System EASILY" by BMo
// November 22, 2021.
// https://www.youtube.com/watch?v=HmXU4dZbaMw

public class Player_Movement : MonoBehaviour
{
    public string loadScene;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public PlayerInputAction pMovement;

    private InputAction move;
    private InputAction fire;
    Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        pMovement = new PlayerInputAction();
    }

    private void OnEnable()
    {
        move = pMovement.Player.Move;
        move.Enable();

        fire = pMovement.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
        //pMovement.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        //pMovement.Disable();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(loadScene);
        }
    }

    // Start is called before the first frame update
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("We fired!");
    }
}
