using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour {

    public GameObject Player;
    public GameObject Carnivore;

    Vector2 mousePos;

    public bool stop = false;

    public bool mouseStart = false;

	// Use this for initialization
	void Start () {

        Player = GameObject.FindGameObjectWithTag("Player");
        Carnivore = GameObject.FindGameObjectWithTag("Carnivore");
        

	}

    // Update is called once per frame
    void Update()
    {


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            Player.GetComponent<Player>().meatNum += 1;
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Carnivore")
        {
            Carnivore.GetComponent<CarTrigger>().reset = true;
            Destroy(gameObject);
            

        }


    }
}
