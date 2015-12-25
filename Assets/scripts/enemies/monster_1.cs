using UnityEngine;
using System.Collections;

public class monster_1 : MonoBehaviour {
	public  bool active = false; // keep moving
	public static float y1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(active == false) transform.Translate(new Vector3(0,y1,0) * Time.deltaTime);
	}
	void OnCollisionEnter2D(Collision2D objectCollision)
	{
		if ((!objectCollision.gameObject.tag.Equals ("sheep"))) {
			active = true;
		}
	}
}
