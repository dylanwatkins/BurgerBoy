using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TruckManager : MonoBehaviour {

	public float truckSpeed;
	public float burgerForce;
	public float maxLeft;
	public float maxRight;
	public GameObject burger;
	float originalForwardSpeed;
	Queue<GameObject> burgers = new Queue<GameObject>();
	public int numberOfBurgers;
	GameObject clone;
	public GameObject movementHandler;

	// Use this for initialization
	void Start () {
		burger.SetActive(false);
		for (int i=0; i<numberOfBurgers;i++){
			clone = Instantiate(burger, new Vector3(transform.position.x + 2f, transform.position.y + 2f, transform.position.z), new Quaternion(0, 0, 90, 0)) as GameObject;
			burgers.Enqueue(clone);
		}
		originalForwardSpeed = movementHandler.GetComponent<MovementHandler>().forwardSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.LeftArrow)) {
			Debug.Log(transform.position.z);
			if (transform.position.z < maxLeft){
				this.transform.Translate(Vector3.left * Time.deltaTime * truckSpeed);
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			Debug.Log(transform.position.z);
			if (transform.position.z > maxRight){
				this.transform.Translate(Vector3.right * Time.deltaTime * truckSpeed);
			}
		}

		if (Input.GetKeyDown(KeyCode.Space)){
			if (burgers.Count > 0) {
				clone = burgers.Dequeue();
				clone.SetActive(true);
				clone.rigidbody.velocity = Vector3.zero;
				clone.transform.position = transform.position;
				clone.transform.rotation = new Quaternion(0, 180, 180, 0);
				clone.rigidbody.AddForce(clone.transform.up * burgerForce);
				clone.rigidbody.AddForce(-clone.transform.right * burgerForce * (movementHandler.GetComponent<MovementHandler>().forwardSpeed  / originalForwardSpeed));
			}
		}

	}

	public void addBurgerToQueue(GameObject addItem){
		burgers.Enqueue(addItem);
	}



}
