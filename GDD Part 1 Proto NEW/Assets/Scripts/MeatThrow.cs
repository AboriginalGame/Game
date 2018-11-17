using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatThrow : MonoBehaviour {

    public GameObject Player;
    public GameObject Carnivore;

    bool mouseStart = false;
    Vector2 mousePos;

    bool stop = false;

	// Use this for initialization
	void Start () {

        Player = GameObject.FindGameObjectWithTag("Player");
        Carnivore = GameObject.FindGameObjectWithTag("Carnivore");


	}
	
	// Update is called once per frame
	void Update () {

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mouseStart == false)
        {
            mousePos = direction;
            mouseStart = true;
        }

        if (stop == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePos, 0.5f);

            if(transform.position.x == mousePos.x && transform.position.y == mousePos.y)
            {
                stop = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Player.GetComponent<Player>().meatNum += 1;
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Carnivore")
        {
            Carnivore.GetComponent<CarTrigger>().reset = true;
            Destroy(gameObject);
           

        }

        if(collision.gameObject.tag == "Ground")
        {
            stop = true;
        }


    }


}


