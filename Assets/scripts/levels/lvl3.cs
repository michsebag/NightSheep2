using UnityEngine;
using System.Collections;

public class lvl3 : MonoBehaviour {
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
		StartCoroutine(createObjectlvl3());
	}
	IEnumerator createObjectlvl3()
	{

		yield return new WaitForSeconds (3f);
		for( int i = 0 ; i < 15 ; i ++){
			if (i % 5 == 0) {
				Instantiate (sheep_3, new Vector2 (33,9),  Quaternion.Euler(0,180,0));
				yield return new WaitForSeconds (2f);
				Instantiate(monster_3, new Vector2(32 ,5), Quaternion.identity) ;
				yield return new WaitForSeconds (1f);
			}
			Instantiate (sheep, new Vector2 (33,9),  Quaternion.Euler(0,180,0));
			yield return new WaitForSeconds (3f);
			if(i % 3 == 0 ){
				Instantiate (sheep_2, new Vector2 (30,9),  Quaternion.Euler(0,180,0));
				yield return new WaitForSeconds (2f);
			}
			Instantiate(monster_2, new Vector2(32 ,5), Quaternion.identity) ;
			yield return new WaitForSeconds (1f);
			Instantiate(monster, new Vector2(32 ,5), Quaternion.identity) ;
			if (i % 7 == 0) {
				yield return new WaitForSeconds (2f);
				Instantiate(monster_4, new Vector2(32 ,5), Quaternion.identity) ;
				yield return new WaitForSeconds (1f);
				Instantiate (sheep_4, new Vector2 (33,9),  Quaternion.Euler(0,180,0));
			}




			yield return new WaitForSeconds(4f);
		}





	}
	// Update is called once per frame
	void Update () {
		if (GameManager.wolfcounter == 34) {
			Application.LoadLevel ("level 4");
		}
	}
}
