using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{
    private float TimeBtwAttcks;
    public float StartTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask WhatIsEnemies;
    public int damage;

     void Update(){
        if(TimeBtwAttcks <= 0){
            // You can attack
            if (Input.GetKey(KeyCode.Space)){                         
                Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, WhatIsEnemies);
                for (int i = 0; i < EnemiesToDamage.Length; i++)
                {
                    EnemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            TimeBtwAttcks = StartTimeBtwAttack;
        }else{
            TimeBtwAttcks -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
