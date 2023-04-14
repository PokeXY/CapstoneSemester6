using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //AudioSource projectile;
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float fireRate = 0.25f;
    private float nextFire = 0.0f;
    public Camera cam;
    Vector2 mousePos;
    Vector2 myPos;
    Vector2 direction;
    public float projectileForce = 20f;
    public AudioSource audioPlayer;

    private void Start()
    {
        //projectile = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        myPos = transform.position;
        direction = (mousePos - myPos).normalized;
        if (Input.GetButtonDown("Fire1")){
            audioPlayer.PlayDelayed(0.10f);
            audioPlayer.Play();
            Shoot();
            //projectile.Play();
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            if (!projectilePrefab)
                return;
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            rb.AddRelativeForce(direction * projectileForce, ForceMode2D.Impulse);
        }

    }
}

