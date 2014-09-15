using UnityEngine;
using System.Collections;

public class WelcomeScreenEventHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame() {
		Application.LoadLevel("Level02");
	}

	public void exitGame() {
		Application.Quit();
	}

	public void loadHighScores() {

	}
}
