using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmpOn : MonoBehaviour {

    public GameObject fireLight;


	// Use this for initialization
	void Start () {



        fireLight.GetComponent<Animator>().SetBool("Lit", true);


    }

    // Update is called once per frame
    void Update () {
   
    }
}
