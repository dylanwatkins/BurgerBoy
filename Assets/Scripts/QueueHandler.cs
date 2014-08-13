using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 

public class QueueHandler : MonoBehaviour {

	//public variables
	public GameObject buildings;
	public GameObject truck;
	public GameObject scenery;

	//private building variables
	Queue<GameObject> buildingQueue = new Queue<GameObject>();
	List<GameObject> buildingList = new List<GameObject>();
	List<GameObject> visibleBuildings = new List<GameObject>();
	GameObject lastBuilding;

	//private scenery variables
	Queue<GameObject> sceneryQueue = new Queue<GameObject>();
	List<GameObject> visibleScenery = new List<GameObject>();
	GameObject lastScenery;




	// Use this for initialization
	void Start () {
		//build the buildings
		initBuildings();
		buildBuildings();

		//build the scenery
		initScenery();
		buildScenery();

	}
	
	// Update is called once per frame
	void Update () {
		//check to remove buildings and scenery
		removeBuildings();
		removeScenery();

		//check to add buildings and scenery
		addBuildings();
		addScenery();


	}









	void initBuildings() {
		//put the buildings into a list to randomize it
		foreach (Transform child in buildings.transform){
			child.transform.Translate(buildings.transform.position);
			buildingList.Add(child.gameObject);
		}
		//add 6 random buildings to a queue
		for (int i=0; i<10; i++){
			GameObject clone;
			clone = Instantiate(buildingList[Random.Range(0, buildingList.Count)], transform.position, transform.rotation) as GameObject;
			clone.SetActive(false);
			buildingQueue.Enqueue(clone);
		}
	}

	void initScenery() {
		//create multiple scenery objects
		for (int i=0; i<4; i++){
			GameObject clone;
			clone = Instantiate(scenery, transform.position, transform.rotation) as GameObject;
			clone.SetActive(false);
			sceneryQueue.Enqueue(clone);
		}
	}


	void buildBuildings() {
		GameObject building = buildingQueue.Dequeue();
		visibleBuildings.Add(building);
		building.SetActive(true);
		building.transform.position = new Vector3(-20f,-3f, 22f);
		building.transform.rotation = Quaternion.Euler(270,0,0);
		lastBuilding = building;
		
		while (buildingQueue.Count > 0) {
			building = buildingQueue.Dequeue();
			visibleBuildings.Add(building);
			building.SetActive(true);
			building.transform.position = new Vector3((lastBuilding.transform.position.x + 5 + building.renderer.bounds.size.x), -3f, 25f); 
			building.transform.rotation = Quaternion.Euler(270,0,0);
			lastBuilding = building;
		}
	}


	void buildScenery() {
		GameObject scenery = sceneryQueue.Dequeue();
		visibleScenery.Add(scenery);
		scenery.SetActive(true);
		scenery.transform.position = new Vector3(333.1791f, 18.32041f, -13.75893f);
		lastScenery = scenery;

		while (sceneryQueue.Count > 0) {
			scenery = sceneryQueue.Dequeue();
			visibleScenery.Add(scenery);
			scenery.SetActive(true);
			scenery.transform.position = new Vector3((lastScenery.transform.position.x + 250f), 18.32041f, -13.75893f);
			lastScenery = scenery;
		}


	}

	void removeBuildings() {
		if (visibleBuildings[0].transform.position.x + 25 < (truck.transform.position.x - 15)){
			visibleBuildings[0].SetActive(false);
			buildingQueue.Enqueue(visibleBuildings[0]);
			visibleBuildings.RemoveAt(0);
		}
	}


	void addBuildings() {
		if (buildingQueue.Count > 0) {
			GameObject building = buildingQueue.Dequeue();
			building.SetActive(true);
			building.transform.position = new Vector3((visibleBuildings[visibleBuildings.Count -1].transform.position.x + 5 + building.renderer.bounds.size.x), -3f, 25f); 
			//building.transform.rotation = Quaternion.Euler(270,0,0);
			visibleBuildings.Add(building);
		}
	}

	void removeScenery() {
		if (visibleScenery[0].transform.position.x + 250 < (truck.transform.position.x - 15)){
			visibleScenery[0].SetActive(false);
			sceneryQueue.Enqueue(visibleScenery[0]);
			visibleScenery.RemoveAt(0);
		}
	}
	
	
	void addScenery() {
		if (sceneryQueue.Count > 0) {
			GameObject scenery = sceneryQueue.Dequeue();
			scenery.SetActive(true);
			scenery.transform.position = new Vector3((visibleScenery[visibleScenery.Count -1].transform.position.x + 250), 18.32041f, -13.75893f); 
			visibleScenery.Add(scenery);
		}
	}
}
