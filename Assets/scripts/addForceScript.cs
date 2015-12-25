using UnityEngine;
using System.Collections;
//push up objects
public class addForceScript : MonoBehaviour {
	public  bool lowerLife = true; // can lower life score
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -6 ) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GetComponent<Rigidbody2D> ().AddForce (transform.up * 5, ForceMode2D.Force);

		} 
		if (transform.position.y > 3 && tag == "monster_7_child") {
	
			GetComponent<Rigidbody2D> ().AddForce (-transform.up * 5, ForceMode2D.Force);

		} 
        if (transform.position.y > 18)
        {
            GetComponent<Rigidbody2D>().AddForce(-transform.up * 5,ForceMode2D.Force );

        }
		if (transform.position.x < -30 && !(tag == "sheep")) {
			Destroy (gameObject);
			if (lowerLife == true) {
				GameManager.life--;
			}
		}
		if (transform.position.y < -18 || transform.position.y > 50) {
			Destroy (gameObject);
		}
    }
}
