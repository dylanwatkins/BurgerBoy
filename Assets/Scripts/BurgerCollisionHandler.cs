using UnityEngine;
using System.Collections;

public class BurgerCollisionHandler : MonoBehaviour {

	public GameObject truck;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		this.gameObject.SetActive(false);
		truck.GetComponent<TruckManager>().addBurgerToQueue(this.gameObject);
	}
}
