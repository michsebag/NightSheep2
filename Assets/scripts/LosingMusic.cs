using UnityEngine;
using System.Collections;

public class LosingMusic : MonoBehaviour {
	public AudioClip shootSound;
	private AudioSource source;


	void Awake () {

		source = GetComponent<AudioSource>();

	}
	// Use this for initialization
	void Start () {
		source.PlayOneShot(shootSound,1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
