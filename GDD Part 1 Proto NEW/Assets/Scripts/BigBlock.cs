using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBlock : MonoBehaviour {

    public GameObject campFire;
    public GameObject Meat;
    public bool scared = true;
	public bool run = false;
	public bool stop = false;
	public bool hitBot = false;
    Rigidbody2D body2D;

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if(scared == false)
        {

            GetComponent<Rigidbody2D>().mass = 100;

        }
	
		if(scared == true && hitBot == false)
        {
            GetComponent<Rigidbody2D>().mass = 1;
            body2D.AddForce(new Vector2(1f, 0f));

        }
			



		if (stop == true) {

			run = false;

			body2D.velocity = (new Vector3(0,0,0));

			scared = false;

		}

		if(body2D.velocity.x == 0){
			stop = false;
		}

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
          
        if(collision.gameObject.tag == "Spear")
        {

            Instantiate(Meat, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
            Instantiate(Meat, new Vector2(transform.position.x + 3, transform.position.y), Quaternion.identity);

            Destroy(gameObject);

        }

    }
}
