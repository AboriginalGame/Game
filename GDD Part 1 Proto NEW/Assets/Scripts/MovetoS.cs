using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovetoS: MonoBehaviour
{

    bool spawned = false;

    public GameObject StoneP;

    public GameObject Alien;

    public GameObject Player;

    float speed = 5f;

    public bool destruct = false;

	public bool reset = false;

    bool timed = false;

    int timer = 0;

    Vector2 target;

    // Use this for initialization
    void Start()
    {

		reset = false;

    }

    // Update is called once per frame
    void Update()
    {

            Alien = GameObject.FindGameObjectWithTag("Alien");
            Player = GameObject.FindGameObjectWithTag("Player");

            ThrowSpear actSpear = Alien.GetComponent<ThrowSpear>();

            if (spawned == false)
            {
                StoneP = GameObject.FindGameObjectWithTag("Spear");
                if (StoneP)
                {
                    target = new Vector2(StoneP.transform.position.x, StoneP.transform.position.y);

                    Debug.Log("stonep" + StoneP);

                    spawned = true;
                }
            }

            float step = speed * Time.deltaTime;

            if (StoneP)
            {
                StoneP.transform.position = Vector2.MoveTowards(StoneP.transform.position, transform.position, step);


                if (StoneP.transform.position == transform.position || reset == true)
                {
                    StoneP.GetComponent<Rigidbody2D>().gravityScale = 0.5f;

                    actSpear.reset = true;
                    destruct = true;

                    Debug.Log("Reset");

                }

                if (destruct == true)
                {
                    Player.GetComponent<throwStone>().spawned = false;
                    Destroy(gameObject);

                    Debug.Log("Destruct");
                }
            }

    }
}
