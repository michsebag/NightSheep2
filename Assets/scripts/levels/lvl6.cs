﻿using UnityEngine;
using System.Collections;

public class lvl6 : MonoBehaviour {

	private float random1;
	private float random2;
	public GameObject sheep; // Regular
	public GameObject sheep_2; // Explosive
	public GameObject sheep_3; // Ninja
	public GameObject sheep_4; // Slow Motion

	public GameObject background;
	public GameObject monster; // Apple
	public GameObject monster_2; // Split fish
	public GameObject monster_3; // Seal - small and fast
	public GameObject monster_4; // Torpedo

	void Start () {
		iTween.RotateTo (background, new Vector3 (0, 0, 120), 10f);
		//		WolfBehaviourScript1.y1 = Random.Range(5f, 8F);
		GameManager.wolfcounter = 0;
		monsters.y1 = Random.Range(4f, 7F);
		monster_1.y1 = Random.Range(7f, 10F);
		GameManager.wolfcounter = 0;
		StartCoroutine(createObjectlvl6());
	}
	IEnumerator createObjectlvl6()
	{
		
		for( int i = 0 ; i < 25 ; i ++){
			random1 = Random.Range (5f, 9F);
			random2 = Random.Range (3f, 9F);
			if (i % 8 == 0) {
				Instantiate (sheep_3, new Vector2 (33, random1), Quaternion.Euler (0, 180, 0));
				yield return new WaitForSeconds (4f);
				Instantiate (monster_3, new Vector2 (32, random2), Quaternion.identity);
				yield return new WaitForSeconds (2f);
			}
			Instantiate (sheep, new Vector2 (33, random1), Quaternion.Euler (0, 180, 0));
			yield return new WaitForSeconds (2f);
			if (i % 4 == 0) {
				Instantiate (sheep_2, new Vector2 (30, random2), Quaternion.Euler (0, 180, 0));
				yield return new WaitForSeconds (3f);
			}
			Instantiate (monster_2, new Vector2 (32, random1), Quaternion.identity);
			yield return new WaitForSeconds (4f);
			Instantiate (monster, new Vector2 (32, random2), Quaternion.identity);
			if (i % 7 == 0) {
				yield return new WaitForSeconds (2f);
				Instantiate (monster_4, new Vector2 (32, random1), Quaternion.identity);
				yield return new WaitForSeconds (1f);
				Instantiate (sheep_4, new Vector2 (33, random2), Quaternion.Euler (0, 180, 0));
			}
		}





	}
	// Update is called once per frame
	void Update () {
		if (GameManager.wolfcounter == 58) {
			Application.LoadLevel ("level 7");
		}
	}
}
