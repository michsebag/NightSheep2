using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class openSceneController : MonoBehaviour {
	public Button button_start;
	public Button button_quit;
	public Button button_credits;
	//Sound
	public AudioClip shootSound;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	public AudioClip clickSound;
	private AudioSource clicksource;
	void Awake () {

		source = GetComponent<AudioSource>();
		clicksource = GetComponent<AudioSource>();

	}

	void start(){
		button_start = button_start.GetComponent<Button> ();
		button_quit = button_quit.GetComponent<Button> ();
		button_credits = button_credits.GetComponent<Button> ();

		float vol = Random.Range (volLowRange, volHighRange);
		source.PlayOneShot(shootSound,vol);

	}
	public void startLevel(){
		clicksource.PlayOneShot(shootSound,1f);
		Application.LoadLevel ("story");
	}
	public void showCredits(){
		clicksource.PlayOneShot(shootSound,1f);
		Application.LoadLevel ("credits");
	}
	public void quit(){
		
	}
}
