using UnityEngine;
using System.Collections;

public class monsters : MonoBehaviour {
	public float speed;

	public static float y1;

	public GameObject monster_7_child;

	public  bool active = false; // keep moving

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(active == false) transform.Translate(new Vector3(-speed,y1,0) * Time.deltaTime);
	}
	void OnCollisionEnter2D(Collision2D objectCollision)
	{
		if( (!objectCollision.gameObject.tag.Equals("sheep")) && active == false ) {
			gameObject.layer = LayerMask.NameToLayer ("bullet");
			active = true;
			GetComponent<Rigidbody2D> ().gravityScale = 1f;
			GetComponent<addForceScript> ().enabled = false;
			if (tag.Equals ("monster_7") && objectCollision.gameObject.tag.Equals("bullet")) {
				
				StartCoroutine (create ());
			} else {
				


					if (!objectCollision.gameObject.tag.Equals("bullet") && !objectCollision.gameObject.tag.Equals( "bullet2")) {
					score.Score++;
					if(!objectCollision.gameObject.tag.Equals("monster_7_child") && !tag.Equals("monster_7_child")){
					GameManager.wolfcounter++;
					}
				}
				}
			}
		}

	IEnumerator create(){
		
		yield return new WaitForSeconds(0.5f);
		Vector3  pos = transform.position;

		Instantiate (monster_7_child, pos + new Vector3(9,3,0), Quaternion.identity);
		Instantiate (monster_7_child, pos + new Vector3(5,6,0), Quaternion.identity);

	}
}
