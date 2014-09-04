using UnityEngine;
using System.Collections;

public class MovementHandler : MonoBehaviour {


	public GameObject truck;
	public Camera mainCamera;
	public float forwardSpeed;
	public int score;


	// Use this for initialization
	void Start () {
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


}
