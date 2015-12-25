using UnityEngine;
using System.Collections;

public class lvl1 : MonoBehaviour {

	public GameObject sheep;
	public GameObject sheep_2;

	public GameObject background;
	public GameObject monster; // Apple
	public GameObject monster_2; // Split fish





	void Start () {
		iTween.RotateTo (background, new Vector3 (0, 0,250), 10f);
		//WolfBehaviourScript1.y1 = Random.Range(4f, 7F);
		monsters.y1 = Random.Range(4f, 7F);
		monster_1.y1 = Random.Range(7f, 10F);
		StartCoroutine(createObjectlvl1());
	}
	IEnumerator createObjectlvl1()
	{
		yield return new WaitForSeconds (3f);
		for( int i = 0 ; i < 10 ; i ++){
			Instantiate (sheep, new Vector2 (33,9),  Quaternion.Euler(0,180,0));
			yield return new WaitForSeconds (3f);
			if(i % 2 == 0 ){
				Instantiate (sheep_2, new Vector2 (30,9),  Quaternion.Euler(0,180,0));
				yield return new WaitForSeconds (3f);
			}
			Instantiate(monster_2, new Vector2(32 ,5), Quaternion.identity) ;
			yield return new WaitForSeconds (2f);
			Instantiate(monster, new Vector2(32 ,5), Quaternion.identity) ;


		

			yield return new WaitForSeconds(4f);
		}





	}
	// Update is called once per frame
	void Update () {
		
		if (GameManager.wolfcounter == 20) {
			Application.LoadLevel ("level 2");
		}
	}
}
