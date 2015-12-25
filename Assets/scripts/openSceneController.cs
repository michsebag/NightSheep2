using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class openSceneController : MonoBehaviour {
	public Button button_start;
	public Button button_quit;
	public Button button_credits;
	void start(){
		button_start = button_start.GetComponent<Button> ();
		button_quit = button_quit.GetComponent<Button> ();
		button_credits = button_credits.GetComponent<Button> ();

	}
	public void startLevel(){
		Application.LoadLevel ("story");
	}
	public void showCredits(){
		Application.LoadLevel ("credits");
	}
	public void quit(){
		
	}
}
