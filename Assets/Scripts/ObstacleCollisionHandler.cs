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

			WWWForm form = new WWWForm();
			form.AddField("initials","KAP");
			form.AddField("score",GameObject.Find("MovementQueueManager").GetComponent<MovementHandler>().score); 
			WWW url = new WWW("http://www.burgermonster.net/game", form);

			if(url.isDone && url.error == null) {
				gameOver.text = url.error;
				print( "Error downloading: " + url.error );
			} 
			else if (url.isDone){
				// show the highscores
				gameOver.text = url.text;
				print(url.text);
			}
			Time.timeScale = 0.0f;

		}
	}
	

}
