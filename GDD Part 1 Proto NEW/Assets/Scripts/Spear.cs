using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour {

	public GameObject Stone;
    GameObject Player;
    GameObject refToM;
    GameObject stoneThrow;

    Rigidbody2D body2D;

    public bool KillP = false;
    public float Speed = 100f;

    Vector2 currentPos;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        refToM = GameObject.FindGameObjectWithTag("Manager");

        body2D = GetComponent<Rigidbody2D>();

        Speed = 500f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Stone = GameObject.FindGameObjectWithTag ("Stone");




            //Vector2 direction = new Vector2(body2D.velocity.x, body2D.velocity.y);
            Vector3 direction = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Speed);
        

        if (KillP == true)
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
