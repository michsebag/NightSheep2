using UnityEngine;
using System.Collections;

public class loadSheep : MonoBehaviour {
	/* the script that changes the sheep in the hand*/
	public static GameObject sheepToFire;
	public static bool hasSheep;
	// Use this for initialization
	void Start () {
		hasSheep = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasSheep == false && nextAmmo.ammo [0] != null) {
			
			StartCoroutine (loadupSheep());
		}

	}
	IEnumerator loadupSheep(){
		hasSheep = true;


		if (nextAmmo.ammo [0] != null) {
			nextAmmo.ammo [0].GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-200, 200));
			yield return new WaitForSeconds (0.5f);

			nextAmmo.ammo [0].GetComponent<Rigidbody2D> ().gravityScale = 0;

			switch (nextAmmo.ammo [0].tag) {
			case "spirit2":
				this.gameObject.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (0.15f, 0.15f, 0);
				break;
			case "spirit":
				this.gameObject.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (0.3f, 0.3f, 0);
				break;
			default:
				this.gameObject.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (0.15f, 0.15f, 0);
				break;
			}

			this.gameObject.GetComponent<SpriteRenderer> ().sprite = nextAmmo.ammo [0].GetComponent<SpriteRenderer> ().sprite;
			this.gameObject.GetComponent<SpriteRenderer> ().color = nextAmmo.ammo [0].GetComponent<SpriteRenderer> ().color;
			this.gameObject.GetComponent<Renderer> ().enabled = true;


		}







	}
}
