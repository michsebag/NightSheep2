using UnityEngine;
using System.Collections;

public class monster_2 : MonoBehaviour {
	public float speed;

	public static float y1;



	public static bool active; // keep moving
	public static bool lowerLife; // can lower life score
	// Use this for initialization
	void Start () {
		lowerLife = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(active == false) transform.Translate(new Vector3(-speed,y1,0) * Time.deltaTime);
	}
	void OnCollisionEnter2D(Collision2D objectCollision)
	{
		if (objectCollision.gameObject.tag != "sheep" && active == false)
		{
			active = true;
			lowerLife = false;
			GetComponent<Rigidbody2D>().gravityScale = 1f;

			GetComponent<addForceScript>().enabled = false;
//			nextAmmo.score++;
			GameManager.wolfcounter++;
		}

	}
}
