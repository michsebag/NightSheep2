using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float speed;
    //target for bullet
    private Vector2 target; //target to move to
    private Vector2 vectorDirecton;
    // Use this for initialization

	//Sound
	public AudioClip shootSound;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	void Awake () {

		source = GetComponent<AudioSource>();

	}

    void Start()
    {
        target = GameManager.targetFire;
        
		Vector2 heading = target - new Vector2(-31.5f,-7f);

		float vol = Random.Range (volLowRange, volHighRange);
		source.PlayOneShot(shootSound,vol);
		GetComponent<Rigidbody2D> ().AddForce (heading.normalized * speed, ForceMode2D.Impulse);




    }

    // Update is called once per frame
    void Update()
    {
		
        
        if ((transform.position.x > 37) || (transform.position.y < -9))
        {
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
		if (!objectCollision.gameObject.tag.Equals("bullet") || !objectCollision.gameObject.tag.Equals("bullet2"))
        {   
			
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;

			score.Score++;
			if(objectCollision.gameObject.tag != "monster_7_child")
			GameManager.wolfcounter++;
        }
    }
// calculate y for bullet target
private float findy(){
         float m = (target.y + 8) / (target.x + 30) ;
         float n = -8 - (m * (-30));
         return 38 * m + n;
     }
   
}
