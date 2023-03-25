using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    void Update(){
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        //TODO*** Add sound to let player know the enemy took damage
        //TODO*** Add animation to let player know the enemy took damage
        //TODO*** Add Stun?
        health -= damage;
        Debug.Log("DAMAGE TAKEN!!");
    }
}
