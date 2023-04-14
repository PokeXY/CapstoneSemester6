using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyShooting : MonoBehaviour
{

    [SerializeField] Transform player;

    //public float speed;
    public bool isInRange;
    //public Animator animator;

    private float distance;
    //private UnityEngine.AI.NavMeshAgent agent;

    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    


    // Start is called before the first frame update
    void Start()
    {
        
        isInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the distance of our player from our enemy

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        // NORMALIIIIIZE
        direction.Normalize();
        // Convert from Radian to degree
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //if (distance < 10)
        //{
        //    isInRange = false;
            
        //    // Rotate our enemy toward the player!

        //    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        //}
        if (distance < 6)
        {
            isInRange = true;
          
        }

        if (isInRange == true)
        {
            timer += Time.deltaTime;

            if (timer > 0.5)
            {
                timer = 0;
                shoot();
            }
        }

        
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

}
