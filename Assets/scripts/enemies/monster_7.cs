using UnityEngine;
using System.Collections;

public class monster_7 : MonoBehaviour {
	// Use this for initialization
	public float speed;

	public static float y1;

	public GameObject monster_7_child;

	public static bool active; // keep moving
	public static bool lowerLife; // can lower life score

	// Use this for initialization
	void Start () {
		lowerLife = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(active == false) transform.Translate(new Vector3(-speed,y1,0) * Time.deltaTime);


		if(transform.position.y < - 15) Destroy(gameObject);
	}
	void OnCollisionEnter2D(Collision2D objectCollision)
	{
		if (objectCollision.gameObject.tag.Equals("bullet"))
		{
			active = true;
			lowerLife = false;
			StartCoroutine (create ());

//			nextAmmo.score++;
			GameManager.wolfcounter++;
		}
		if ((objectCollision.gameObject.tag.Equals("monster") || objectCollision.gameObject.tag.Equals("monster_7")) && active == false) {
			active = true;
			lowerLife = false;
			GetComponent<Rigidbody2D>().gravityScale = 1f;

			GetComponent<addForceScript>().enabled = false;

			score.Score++;
			GameManager.wolfcounter++;
		}
}
			IEnumerator create(){
			yield return new WaitForSeconds(0.5f);
			Instantiate (monster_7_child, transform.position, Quaternion.identity);
			Instantiate (monster_7_child, transform.position + new Vector3(2,1,0), Quaternion.identity);
			Destroy (gameObject);
		}
}
