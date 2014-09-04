using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObstacleCollisionHandler : MonoBehaviour {

	public Text gameOver;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		collider.gameObject.SetActive(false);
		int lives = this.GetComponent<TruckManager>().lives;
		if (lives > 0) {
			this.GetComponent<TruckManager>().lives -= 1;
			this.GetComponent<TruckManager>().burgerLives[lives-1].gameObject.SetActive(false);
		}
		checkEndGame();
	}

	void checkEndGame(){
		if (this.GetComponent<TruckManager>().lives == 0) {
			Debug.Log("GAME OVER");
			this.gameObject.SetActive(false);
			gameOver.gameObject.SetActive(true);
			Time.timeScale = 0.0f;
		}
	}
	

}
