using UnityEngine;
using System.Collections;

public class start_animation : MonoBehaviour {
	public Animator anim;
	// Use this for initialization
	void Start () {
		StartCoroutine (wait ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator wait(){
		yield return new WaitForSeconds (2f);
		anim.SetBool ("closed_eyes", true);
		yield return new WaitForSeconds (3f);
		Application.LoadLevel ("level 1");
	}
}
