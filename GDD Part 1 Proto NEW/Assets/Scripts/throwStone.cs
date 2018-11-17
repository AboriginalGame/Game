using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwStone : MonoBehaviour {

    public GameObject Stone;
    public bool thrown = true;

    private Camera cam;

    public bool spawned = false;

	// Use this for initialization
	void Start () {

        cam = Camera.main;

        


    

    }

    // Update is called once per frame

    void Update()
    {

        if (thrown == true)
        {

            if (Input.GetMouseButtonDown(0))
            {

                if (spawned == false)
                {
                    Instantiate(Stone, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);

                    spawned = true;

                    thrown = false;
                }



            }

        }
    }
}