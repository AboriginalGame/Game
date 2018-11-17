using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour {

    public bool moveLeft = false;
    public bool  moveRight = false;
    public bool reset = false;
    public GameObject Target;

    Rigidbody2D body2D;

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if(reset == true)
        {
            moveLeft = false;
            moveRight = false;
            reset = false;

        }
        Target = GameObject.FindGameObjectWithTag("Meat");


        if (Target)
        {

           


            if (reset == false)
            {
                if (moveLeft == true)
                {
                    body2D.AddForce(new Vector2(-2f, 0f));
                    moveRight = false;

                }

                if (moveRight == true)
                {
                    body2D.AddForce(new Vector2(2f, 0f));
                    moveLeft = false;
                }

            }

        }

       
    }
}
