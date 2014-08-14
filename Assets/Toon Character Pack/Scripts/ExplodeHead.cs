using UnityEngine;
using System.Collections;

public class ExplodeHead : MonoBehaviour 
{


	public ParticleSystem Explosion;
	public GameObject Root;
	public Color bloodColor;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Explode()
	{
		Explosion.startColor = bloodColor;
		Instantiate(Explosion, Root.transform.position, Quaternion.identity);



	}

}
