using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CampFire : MonoBehaviour {

    public bool lit;
	public bool hitting = false;


    public GameObject Player;
	public GameObject Block;
    public GameObject fireLight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        lit = GetComponent<Animator>().GetBool("Alight");

        if(lit == true)
        {

            fireLight.GetComponent<Animator>().SetBool("Lit", true);

        }

		if (hitting == true && lit == true) {

			Block.GetComponent<BigBlock> ().scared = true;

		}

    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.gameObject.tag == "Block") {
			hitting = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Block")
		{

			hitting = false;
		}
	}

    
}
