using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
  

    // Update is called once per frame
    private void Update(){
    }

    private void OnCollisionEnter2D(Collision2D collision){
        var enemy = collision.collider.GetComponent<EnemyCharacter>();
        if (enemy)
        {
            enemy.TakeHit(1);
        }

        Destroy(gameObject);
    }
}
