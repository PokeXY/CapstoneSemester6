using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 4.5f;

    // Update is called once per frame
    private void Update(){
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        var enemy = collision.collider.GetComponent<EnemyCharacter>();
        if (enemy){
            enemy.TakeHit(1);
        }
        var enemy2 = collision.collider.GetComponent<EnemyShooting>();
        if (enemy2)
        {
            enemy2.TakeHit(1);
        }

        Destroy(gameObject);
    }
}
