using UnityEngine;

public class PaulsControllerCharactcer : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    public float Hitpoints;
    public float MaxHitpoints = 5;
    public HealthBarBehaviour Healthbar;

    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;

    private Rigidbody2D _rigidbody;

    public AudioSource audioPlayer;

    // Start is called before the first frame update
    private void Start(){
        _rigidbody = GetComponent<Rigidbody2D>();
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeHit(float damage){
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update(){
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f){
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1")){
            audioPlayer.Play();
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }

    }
}
