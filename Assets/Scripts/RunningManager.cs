using UnityEngine;
using System.Collections;

public class RunningManager : MonoBehaviour {


	
	private AnimationCurve anim;
	private Keyframe[] ks;
	int choice;

	void Start() {
		ks = new Keyframe[10];
		int i = 0;
		while (i < ks.Length) {
			//if (i <= 3 || i > 6 && i < 10) {
			ks[i] = new Keyframe(i, Mathf.Sin(i)*0.01f);
				i++;
//			}
//			else if (i > 3 && i <= 6 || i >= 10 && i <= 14){
//				ks[i] = new Keyframe(i, i * 0.005f);
//				i++;
//			}

		}
		anim = new AnimationCurve(ks);
		choice = Random.Range(0,3);

	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Animator>().Play("Run");
		if (choice == 0){
			if (Time.time % 1 < 0.45f){
				Debug.Log("Negative");
				this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0, 215, 0), Time.deltaTime);
			}
			else {
				Debug.Log("Positive");
				this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0, -45, 0), Time.deltaTime);
			}
			//		this.transform.position += new Vector3(-Time.time * 0.008f, 0, anim.Evaluate(Time.time));
		}

		if (Time.time < anim.length) {
			anim.AddKey(new Keyframe(anim.length+1, Mathf.Cos(anim.length+1)*0.05f));
		}

	}
}
