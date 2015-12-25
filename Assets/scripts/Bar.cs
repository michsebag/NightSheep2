using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {
	public Sprite Bar_full;
	public Sprite Bar_two_lives;
	public Sprite Bar_one_life;
	public Sprite Bar_empty;


	public  GameObject monster_icon;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		int control = GameManager.life;
		switch (control) {
		case 3:
			GetComponent<SpriteRenderer> ().sprite = Bar_full;
			monster_icon.transform.position = new Vector2 (27f, 33.5f);
			break;
		case 2:
			GetComponent<SpriteRenderer> ().sprite = Bar_two_lives;
			monster_icon.transform.position = new Vector2 (13.9f, 33.5f);
			break;
		case 1:
			GetComponent<SpriteRenderer> ().sprite = Bar_one_life;
			monster_icon.transform.position = new Vector2 (-1.27f, 33.5f);
			break;
		default :
			GetComponent<SpriteRenderer> ().sprite = Bar_empty;
			monster_icon.transform.position = new Vector2 (-15.27f, 33.5f);
			break;
		}
	}
}
