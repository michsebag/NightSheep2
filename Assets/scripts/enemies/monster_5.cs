using UnityEngine;
using System.Collections;

public class monster_5 : MonoBehaviour {
	public  bool active = false; // keep moving
	private float speed = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	//	if(active == false)iTween.MoveAdd (this.gameObject, new Vector3 (0, spe, 0), Time.deltaTime);
	if(active == false) transform.Translate(new Vector3(0,speed,0) * Time.deltaTime);
		speed += 0.005f;
	}
	void OnCollisionEnter2D(Collision2D objectCollision)
	{
		if ((!objectCollision.gameObject.tag.Equals ("sheep"))) {
			active = true;
		}
}
}