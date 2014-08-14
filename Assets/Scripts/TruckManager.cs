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
	float center;

	// Use this for initialization
	void Start () {
		burger.SetActive(false);
		for (int i=0; i<numberOfBurgers;i++){
			clone = Instantiate(burger, new Vector3(transform.position.x + 2f, transform.position.y + 2f, transform.position.z), new Quaternion(0, 0, 90, 0)) as GameObject;
			burgers.Enqueue(clone);
		}
		originalForwardSpeed = movementHandler.GetComponent<MovementHandler>().forwardSpeed;
		center = this.transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			if (transform.position.z < maxLeft){
				if (this.transform.rotation.y <= center){
					this.transform.Translate(Vector3.left * Time.deltaTime * truckSpeed);
					this.transform.RotateAround(new Vector3(this.transform.position.x - 5f, this.transform.position.y, this.transform.position.z),-Vector3.up, 1f);
				}
				else {
					this.transform.RotateAround(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),-Vector3.up, 5f);
					this.transform.Translate(Vector3.left * Time.deltaTime * truckSpeed * 3 / 4);
				}
			}
			else if (this.transform.rotation.y < center){
				this.transform.RotateAround(new Vector3(this.transform.position.x - 5f, this.transform.position.y, this.transform.position.z),Vector3.up, 1f);	
				if (this.transform.position.z < maxLeft){
					this.transform.Translate(Vector3.right * Time.deltaTime * truckSpeed);
				}
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			if (transform.position.z > maxRight){
				if (this.transform.rotation.y >= center){
					this.transform.Translate(Vector3.right * Time.deltaTime * truckSpeed);
					this.transform.RotateAround(new Vector3(this.transform.position.x - 5f, this.transform.position.y, this.transform.position.z),Vector3.up, 1f);
				}
				else {
					this.transform.RotateAround(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),Vector3.up, 5f);
					this.transform.Translate(Vector3.right * Time.deltaTime * truckSpeed * 3 / 4);
				}
			}
			else if (this.transform.rotation.y > center){
				this.transform.RotateAround(new Vector3(this.transform.position.x - 5f, this.transform.position.y, this.transform.position.z),-Vector3.up, 1f);
				if (this.transform.position.z > maxRight){
					this.transform.Translate(Vector3.left * Time.deltaTime * truckSpeed);
				}
			}
		}
		else {
			//this.transform.LookAt(forwardTarget.transform);
			if (this.transform.rotation.y > center + 0.01f){
				this.transform.RotateAround(new Vector3(this.transform.position.x - 5f, this.transform.position.y, this.transform.position.z),-Vector3.up, 0.5f);	
				if (this.transform.position.z < maxRight){
					this.transform.Translate(Vector3.left * Time.deltaTime * truckSpeed);
				}
			}
			else if (this.transform.rotation.y < center){
				this.transform.RotateAround(new Vector3(this.transform.position.x - 5f, this.transform.position.y, this.transform.position.z),Vector3.up, 0.5f);
				if (this.transform.position.z > maxLeft){
					this.transform.Translate(Vector3.right * Time.deltaTime * truckSpeed);
				}
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
				clone.rigidbody.AddForce(-clone.transform.right * burgerForce * (movementHandler.GetComponent<MovementHandler>().forwardSpeed * 0.25f));
			}
		}

	}

	public void addBurgerToQueue(GameObject addItem){
		burgers.Enqueue(addItem);
	}



}
