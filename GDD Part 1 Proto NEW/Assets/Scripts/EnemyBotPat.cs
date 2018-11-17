using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBotPat : MonoBehaviour
{


    Rigidbody2D body2D;

	public GameObject Block;

    Vector2 tempPos;

    float xSpeed = 1f;
    float ySpeed = 0f;

    // Use this for initialization
    void Start()
    {

        body2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        tempPos = body2D.transform.position;

        tempPos.x += xSpeed * Time.deltaTime;
        tempPos.y += ySpeed * Time.deltaTime;

        body2D.transform.position = tempPos;

        if (body2D.position.x > 6.11)
        {

            xSpeed = -1f;
        }

        if (body2D.position.x < 1.2)
        {

            xSpeed = 1f;
        }

    }

	void OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.tag == "Block")
		{
			Block.GetComponent<BigBlock> ().hitBot = true;
			Block.GetComponent<BigBlock> ().scared = false;
			Block.GetComponent<BigBlock> ().stop = true;
			print("hit");
			Destroy(gameObject);
		}

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
//        print(collision.gameObject.name);



        if (collision.gameObject.tag == "Spear")
        {
            print("hitting");
            Destroy(this.gameObject);
        }
			


    }
}
