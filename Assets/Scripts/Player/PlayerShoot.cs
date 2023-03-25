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

    public float projectileForce = 20f;

    private void Start()
    {
        //projectile = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

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
            rb.AddRelativeForce(Vector2.up * projectileForce, ForceMode2D.Impulse);
        }

    }
}

