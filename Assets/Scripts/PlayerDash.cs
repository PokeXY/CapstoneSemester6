using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Rigidbody2D rb;
    private float dashSpeed = 600000;
    bool isDashing = true;
    float dashCooldown = 300;
    private void FixedUpdate()
    {
        if (dashCooldown == 0)
        {
            isDashing = true;
        }
        else
        {
            dashCooldown -= 1;
            Debug.Log(dashCooldown);

        }

        rb.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.Space) && isDashing)
        {
            Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;

            rb.AddForce(mouseDirection * dashSpeed * Time.fixedDeltaTime);
            isDashing = false;
            dashCooldown = 300;

        }
    }
}
