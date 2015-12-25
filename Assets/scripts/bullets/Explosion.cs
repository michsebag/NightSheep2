

using UnityEngine;
using System.Collections;


public class Explosion : MonoBehaviour
{
    public float Power;
    public float Radius;

	public ParticleSystem explosion;
    public GameObject bullet;
	public GameObject monster_child;
    public static bool collision; // active explosion
    public static bool active; //active function
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
		
        active = true;

		float vol = Random.Range (volLowRange, volHighRange);
		source.PlayOneShot(shootSound,vol);
    }

    // Update is called once per frame
    void Update()
    {
#if (UNITY_ANDROID || UNITY_IPHONE)

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Vector3 fingerPos = Input.GetTouch(0).position;
			fingerPos.z = 10;
			Vector3 objPos = Camera.main.ScreenToWorldPoint(fingerPos);
			AddExplosionForce(rigidbody2D, Power * 100, objPos, Radius);
		}

#endif

#if (UNITY_EDITOR || UNITY_WEBPLAYER)

		if ((Input.GetMouseButtonDown(0) && active )|| collision)
        {

		StartCoroutine(particle());

           
            
        }



    }
	IEnumerator particle(){
		Vector3 objPos =  transform.position;
		Instantiate(explosion, objPos, Quaternion.identity);
		explosion.transform.position = objPos;
		explosion.Play();
		Destroy(gameObject);

		Collider2D[] colliders = Physics2D.OverlapCircleAll(objPos,Radius);
		active = false;
		collision = false;
		foreach (Collider2D item in colliders)
		{


			if (item != null &&(item.tag.Equals("monster_7")|| item.tag.Equals("monster") ||  item.tag.Equals("monster_7_child")))
			{	
				item.gameObject.layer = LayerMask.NameToLayer ("bullet");
				item.GetComponent<monsters> ().active = true;
				score.Score++;
				if( !item.tag.Equals("monster_7_child"))
					GameManager.wolfcounter++;
				if(item.tag.Equals("monster_7")){
					
				//	item.GetComponent<Renderer> ().enabled = false;

					Instantiate (monster_child, item.transform.position + new Vector3(10,3 ,0), Quaternion.identity);
					Instantiate (monster_child, item.transform.position + new Vector3(2,10,0), Quaternion.identity);

					//Destroy (item.gameObject);
					//break;

				} 
				item.GetComponent<addForceScript> ().lowerLife = false;
				item.GetComponent<addForceScript>().enabled = false;
				item.GetComponentInChildren<ParticleSystem> ().enableEmission = true;
				item.GetComponentInChildren<ParticleSystem> ().Play();
				var dir = (item.transform.position - objPos);
				item.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
				item.GetComponent<Rigidbody2D>().AddForce(dir.normalized * Power * Radius);
				item.GetComponent<Rigidbody2D>().gravityScale = 1f;


			}

		}


		GameManager.sheepExplodeGo = false;
		yield return new WaitForSeconds(3);
		foreach (Collider2D item in colliders) {
			if (item.tag.Equals("monster_7")|| item.tag.Equals("monster") ||  item.tag.Equals("monster_7_child"))
				item.GetComponentInChildren<ParticleSystem> ().Stop();
		}
		explosion.Stop ();
		Destroy (explosion);   
	}
#endif 
    }



