using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {

    public GameObject PlayerPos;
    public GameObject Spear;
    public GameObject SpearS;
    public bool attack = false;
    public bool move = false;

    public float step = 10f;
    public float speed;

	// Use this for initialization
	void Start () {

        PlayerPos = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {

        step = speed * Time.deltaTime;

        if(attack == true)
        {
            Instantiate(Spear, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
            SpearS = GameObject.FindGameObjectWithTag("Spear");
            SpearS.GetComponent<Rigidbody2D>().gravityScale = 0;
            move = true;
            attack = false;
        }

        if(move == true)
        {
            //print("Moving");
            if (SpearS)
            {
                SpearS.GetComponent<Spear>().KillP = true;
            }
        }

        //refToM.GetComponent<Game>().PlayerState = "Player: Dead";

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            attack = true;
        }
    }
}
