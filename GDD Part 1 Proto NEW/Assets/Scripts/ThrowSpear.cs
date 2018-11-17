using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpear : MonoBehaviour {

    public bool spawned = false;

    public bool hitGround = false;

    public bool reset = false;

 

    public GameObject Spear;

    public GameObject StoneP;

    float speed = 1f;

    Vector2 target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (reset == true)
        {
            hitGround = false;
            spawned = false;

            reset = false;
        }


        if (hitGround == true && spawned == false){


            target = new Vector2(StoneP.transform.position.x, StoneP.transform.position.y);
           

            Instantiate(Spear, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);

            spawned = true;
        }

    }
}