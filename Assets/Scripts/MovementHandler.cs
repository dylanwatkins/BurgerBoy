using UnityEngine;
using System.Collections;

public class MovementHandler : MonoBehaviour {


	public GameObject truck;
	public Camera mainCamera;
	public float forwardSpeed;
	public int score;


	// Use this for initialization
	void Start () {
		forwardSpeed = 4;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//move the truck in the direction of the target
		truck.transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
		//move the camera
		mainCamera.transform.position = new Vector3(truck.transform.position.x - 28, truck.transform.position.y + 13, mainCamera.transform.position.z);
		//increase the speed
		forwardSpeed += 0.01f;
	}

	void OnGUI() {
		GUI.Box(new Rect (Screen.width - 100, Screen.height - 60 ,90,50),  "SCORE: " + score.ToString());
		GUI.Box(new Rect(Screen.width -100, Screen.height - 110, 90, 40), "LIVES: " + truck.gameObject.GetComponent<TruckManager>().lives );
		if (truck.gameObject.GetComponent<TruckManager>().lives == 0) {
			GUI.Box(new Rect(Screen.width / 3, Screen.height / 3, Screen.width / 3, Screen.height / 4), "GAME OVER \n \n \n Final Score: " + score.ToString());
		}
	}
}
