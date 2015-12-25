using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class score : MonoBehaviour {
	public static int Score = 0;
	public Text scoreText; // GUI text for score
	// Use this for initialization
	void Start () {
		scoreText.text = "" + Score;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "" +  Score;
	}
}
