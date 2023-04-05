using UnityEngine;

public class PaulsEnemyBehaviourt : MonoBehaviour{

    public float Hitpoints;
    public float MaxHitpoints = 5;
    public HealthBarBehaviour Healthbar;
    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start(){
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    // Update is called once per frame
     public void TakeHit(float damage){
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0){
            audioPlayer.Play();
            Destroy(gameObject);
        }
    }
}
