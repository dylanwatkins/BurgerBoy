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

		if (collision.gameObject.tag == "Respawn"){
			ExplodeHead explo = collision.gameObject.GetComponent<ExplodeHead>();
			if(explo) {
				explo.Explode();//("ToonCharacterController");
				collision.gameObject.SetActive(false);
				GameObject.Find("MovementQueueManager").GetComponent<MovementHandler>().score += 100;
			}
			

		}


	}
	
}
