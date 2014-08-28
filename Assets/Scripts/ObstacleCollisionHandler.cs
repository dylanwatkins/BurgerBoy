using UnityEngine;
using System.Collections;

public class ObstacleCollisionHandler : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		collider.gameObject.SetActive(false);
		if (this.GetComponent<TruckManager>().lives > 0) {
			this.GetComponent<TruckManager>().lives -= 1;
		}
		checkEndGame();
	}

	void checkEndGame(){
		if (this.GetComponent<TruckManager>().lives == 0) {
			Debug.Log("GAME OVER");
			this.gameObject.SetActive(false);
			Time.timeScale = 0.0f;
		}
	}
	

}
