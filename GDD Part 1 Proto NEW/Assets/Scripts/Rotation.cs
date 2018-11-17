using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public GameObject pivot;

	bool startPos = false;
	public bool weighted = false;
	bool clamp = false;
	int timer = 0;
	int retTimer = 0;
	bool retTimerB = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (retTimerB == true) {

			retTimer += 1;

			if (retTimer > 30) {

				clamp = false;
				weighted = false;
				retTimerB = false;
				retTimer = 0;
			}
		}


		if (weighted == false && startPos == true) {

			timer += 1;

			if (timer > 90) {

				this.transform.RotateAround (pivot.transform.position, new Vector3 (0, 0, -10f), 1f);

			}

		}

		if (weighted == true && clamp == false) {
			timer = 0;
			this.transform.RotateAround (pivot.transform.position, new Vector3 (0, 0, 10f), 0.2f);
			startPos = true;

		}

//		print (this.transform.eulerAngles.z);

		if (this.transform.eulerAngles.z > 100) {
			this.transform.eulerAngles = new Vector3(0,0,100f);
			clamp = true;
		}

		if (this.transform.eulerAngles.z < 45) {
			this.transform.eulerAngles = new Vector3(0,0,45f);
			timer = 0;
			startPos = false;
		}


	}

	void OnCollisionEnter2D(Collision2D Collision){

		if (Collision.gameObject.tag == "Player") {

			weighted = true;

		}

	}
	void OnCollisionExit2D(Collision2D Collision){

		if (Collision.gameObject.tag == "Player") {

			retTimerB = true;
		}

	}

}
