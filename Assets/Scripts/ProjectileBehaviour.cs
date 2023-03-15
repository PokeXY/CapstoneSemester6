using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 4.5f;
  

    // Update is called once per frame
    private void Update(){
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        var enemy = collision.collider.GetComponent<PaulsEnemyBehaviourt>();
        if (enemy){
            enemy.TakeHit(1);
        }


        Destroy(gameObject);
    }
}
