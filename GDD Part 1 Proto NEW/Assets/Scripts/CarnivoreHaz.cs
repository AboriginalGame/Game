using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreHaz : MonoBehaviour {

    public GameObject End;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Carnivore")
        {
            Instantiate(End, new Vector2(transform.position.x , transform.position.y), Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
