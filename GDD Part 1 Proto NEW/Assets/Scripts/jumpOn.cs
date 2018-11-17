using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpOn : MonoBehaviour {

	public bool hitting = false;
	public GameObject Player;
	public GameObject Neck;
    public bool Timer = false;
    public int Time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if(Timer == false)
        {
            Time = 0;

        }

        if(Timer == true)
        {
            Time += 1;

            if(Time > 180)
            {
                hitting = false;
                Timer = false;
            }


        }

		if (hitting == true) {

			if (Player.GetComponent<Rigidbody2D>().velocity.y > 0f && Player.transform.position.y > (this.transform.position.y + 1.2f)) {

				this.GetComponent<BoxCollider2D> ().isTrigger = false;
				Neck.GetComponent<BoxCollider2D> ().isTrigger = false;

			}
		}
        if (hitting == false)
        {

                this.GetComponent<BoxCollider2D>().isTrigger = true;
                Neck.GetComponent<BoxCollider2D>().isTrigger = true;

            
        }


    }

	void OnTriggerEnter2D(Collider2D Collision){


		if (Collision.gameObject.tag == "Player") {

			hitting = true;
           


		}

	}

    void OnCollisionExit2D(Collision2D Collision)
    {

        if (Collision.gameObject.tag == "Player")
        {

            Timer = true;


        }

    }

    void OnCollisionEnter2D(Collision2D Collision)
    {

        if (Collision.gameObject.tag == "Player")
        {

            Timer = false;


        }

    }
}
