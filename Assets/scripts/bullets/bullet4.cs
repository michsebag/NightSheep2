using UnityEngine;
using System.Collections;

public class bullet4 : MonoBehaviour {


	public float speed;
	//target for bullet
	private Vector2 target; //target to move to
	private Vector2 vectorDirecton;
	// Use this for initialization
	void Awake () {
		target = GameManager.targetFire;

		Vector2 heading = target - new Vector2(-31.5f,-7f);
		GetComponent<Rigidbody2D> ().AddForce (heading.normalized * speed, ForceMode2D.Impulse);
		StartCoroutine (slowMotion ());

	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.position.x > 37) || (transform.position.y < -9))
		{
			Destroy(gameObject);
		}
	}
	IEnumerator slowMotion()
	{
		Time.timeScale = 0.5f;
		yield return new WaitForSeconds(1.5f);
		Time.timeScale = 1f;

	}
	void OnCollisionEnter2D(Collision2D objectCollision)
	{
		if (!objectCollision.gameObject.tag.Equals("bullet") || !objectCollision.gameObject.tag.Equals("bullet2" ))
		{   
			
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Collider2D>().enabled = false;
			score.Score++;
			if(objectCollision.gameObject.tag != "monster_7_child")
				GameManager.wolfcounter++;
		

		}

	}
}
