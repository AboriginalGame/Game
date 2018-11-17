using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    Rigidbody2D body2D;

    bool moveS = false;
    bool thrown = false;

    public float Speed = 300f;
    public float xSpeed = 0f;
    public float ySpeed = 0f;
    int Timer = 0;

    bool Timeout = false;

    public GameObject Player;

    Vector2 mousePos;

    public GameObject Enemy;

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();

        Enemy = GameObject.Find("alienBeige");
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        Timer += 1;

        if(Timer > 150)
        {

            Timeout = true;
        }

        if(Timeout == true)
        {
            
            Player.GetComponent<throwStone>().thrown = true;
            Enemy.GetComponent<ThrowSpear>().reset = true;
            Player.GetComponent<throwStone>().spawned = false;
            Destroy(gameObject);
        }



        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Speed * Time.deltaTime);

        if(thrown == false)
        {
            mousePos = direction;
            moveS = true;
            thrown = true;

        }
       

        //body2D.AddForce(new Vector2(xSpeed, ySpeed) * Speed * Time.deltaTime);

        if(moveS == true)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, mousePos, 0.5f);      
        }

        if(this.transform.position.x == mousePos.x)
        {
            moveS = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ThrowSpear actSpear = Enemy.GetComponent<ThrowSpear>();

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Block")
        {
            moveS = false;
            actSpear.hitGround = true;
            body2D.velocity = Vector2.zero;
            //Player.GetComponent<throwStone>().thrown = true;

        }
    }
}
