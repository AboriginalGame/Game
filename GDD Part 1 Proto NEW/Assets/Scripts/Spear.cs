using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour {

	public GameObject Stone;
    GameObject Player;
    GameObject refToM;
    GameObject stoneThrow;

    public bool KillP = false;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        refToM = GameObject.FindGameObjectWithTag("Manager");
	}
	
	// Update is called once per frame
	void Update () {
		Stone = GameObject.FindGameObjectWithTag ("Stone");


        if(KillP == true)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;

            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, 0.1f);
        }
	}

	void OnCollisionEnter2D(Collision2D col){
		print ("hit");

		if (col.gameObject.tag == "Ground") {


			print ("hit");
            Player.GetComponent<throwStone>().thrown = true;
			Stone.GetComponent<MovetoS> ().reset = true;


		}

	}


	void OnTriggerEnter2D(Collider2D col){
		print ("hit " + (col.gameObject.tag));

		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Bridge") {

            Player.GetComponent<throwStone>().thrown = true;
            print ("spear hit trigger " + (col.gameObject.tag));

            if (Stone)
            {
                
                Stone.GetComponent<MovetoS>().reset = true;
            }
            
            Destroy(gameObject);
           
		}

        if(col.gameObject.tag == "Player")
        {


            Destroy(col.gameObject);
            refToM.GetComponent<Game>().PlayerState = "Player: Dead";


        }

	}
}
