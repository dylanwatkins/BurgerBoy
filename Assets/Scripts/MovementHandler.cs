using UnityEngine;
using System.Collections;

public class MovementHandler : MonoBehaviour {


	public GameObject truck;
	public Camera mainCamera;
	public float forwardSpeed;


	// Use this for initialization
	void Start () {
		forwardSpeed = 4;
	}
	
	// Update is called once per frame
	void Update () {
		truck.transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
		mainCamera.transform.position = new Vector3(truck.transform.position.x - 28, truck.transform.position.y + 13, mainCamera.transform.position.z);
		forwardSpeed += 0.01f;
	}
}
