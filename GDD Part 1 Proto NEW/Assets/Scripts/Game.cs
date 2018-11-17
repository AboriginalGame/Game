using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public TextMesh PlayerT;
    public string PlayerState = "Player: Alive";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.R))
        {

            SceneManager.LoadScene(0);

        }

        PlayerT.text = PlayerState;

	}
}
