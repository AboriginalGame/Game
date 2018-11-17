using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    Rigidbody2D body2D;
    public float xSpeed = 0f;
    public float ySpeed = 0f;
    public float thrust = 300f;
    public TextMesh meatText;

    string xDir = "idle";

    public float meatNum = 0;

    public bool grounded = false;
    public bool hasTorch;


    public int jCount = 0;
    public float jCountMax = 7f;


    public GameObject Meat;

    public GameObject Manager;

    public bool jump = false;

	// Use this for initialization
	void Start () {

        body2D = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        body2D.AddForce(new Vector2(xSpeed, ySpeed) * thrust * Time.deltaTime);

        meatText.text = "Meat: " + meatNum.ToString();

        if (Input.GetKey(KeyCode.A))
        {
            xSpeed = -1f;
            xDir = "Left";
        }

        if (Input.GetKey(KeyCode.D))
        {
            xSpeed = 1f;
            xDir = "Right";
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            xSpeed = 0f;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            xSpeed = 0f;
        }

        if (Input.GetKeyUp(KeyCode.Space) && grounded == true)
        {
            jump = true;        
        }

        if(jump == true)
        {
            jCount += 1;
            ySpeed = 10f;
        }

        if (jCount >= jCountMax)
        {
            grounded = false;
            jCount = 0;
            jump = false;
        }

        if (grounded == false)
        {
            ySpeed = 0f;
            
        }

        

    

        if(meatNum > 0)
        {

            if (Input.GetMouseButtonDown(1))
            {
                if (xDir == "Left")
                {
                    Instantiate(Meat, new Vector2(transform.position.x - 1, transform.position.y + 1), Quaternion.identity);
                    meatNum -= 1;
                }

                if (xDir == "Right")
                {
                    Instantiate(Meat, new Vector2(transform.position.x +1 , transform.position.y + 1), Quaternion.identity);
                    meatNum -= 1;
                }

            }


        }

        




    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Campfire")
        {
            GetComponent<Animator>().SetBool("campFire", true);
            hasTorch = GetComponent<Animator>().GetBool("campFire");
            

        }

        if(collision.gameObject.tag == "End")
        {

            Manager.GetComponent<Game>().PlayerState = "You Win, Well Done";

        }

        
    }
}
