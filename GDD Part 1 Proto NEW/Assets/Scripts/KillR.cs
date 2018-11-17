using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillR : MonoBehaviour {

    public GameObject Player;
    public GameObject refToM;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        refToM = GameObject.FindGameObjectWithTag("Manager");

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.name == "GameObject")
        {
            if (collision.gameObject.tag == "Player")
            {
                //refToM.GetComponent<Game>().PlayerState = "Player: Dead";
                //Destroy(Player);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            refToM.GetComponent<Game>().PlayerState = "Player: Dead";


            Destroy(Player);
        }
    }
}
