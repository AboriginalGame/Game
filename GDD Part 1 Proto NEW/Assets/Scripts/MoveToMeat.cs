using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMeat : MonoBehaviour {

    bool Move = false;
    public GameObject Parent;
    public GameObject Target;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(Move == true)
        {
            Target = GameObject.FindGameObjectWithTag("Meat");

            if (Target.transform.position.x < this.transform.position.x)
            {
                Parent.GetComponent<CarTrigger>().moveLeft = true;
                Parent.GetComponent<CarTrigger>().moveRight = false;
            }

            if(Target.transform.position.x > this.transform.position.x)
            {
                Parent.GetComponent<CarTrigger>().moveRight = true;
                Parent.GetComponent<CarTrigger>().moveLeft = false;
            }

        }

        
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Meat")
        {          
            Move = true;
        }
    }
}
