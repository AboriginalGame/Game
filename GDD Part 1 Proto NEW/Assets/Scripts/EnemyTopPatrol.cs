using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTopPatrol : MonoBehaviour {


    Rigidbody2D body2D;

    Vector2 tempPos;

    float xSpeed = 1f;
    float ySpeed = 0f;

	// Use this for initialization
	void Start () {

        body2D = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        tempPos = body2D.transform.position;

        tempPos.x += xSpeed * Time.deltaTime;
        tempPos.y += ySpeed * Time.deltaTime;

        body2D.transform.position = tempPos;

        if(body2D.position.x > 4.82) {

            xSpeed = -1f;
        }

        if (body2D.position.x < 2.9)
        {

            xSpeed = 1f;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);



        if (collision.gameObject.tag == "Spear")
        {
            print("hitting");
            Destroy(this.gameObject);
        }

    }
}
