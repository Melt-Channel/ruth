using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantTransmissionFilm : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//gameObject.transform.position.y = player.transform.position.y;
		gameObject.transform.position = new Vector2 (gameObject.transform.position.x, player.transform.position.y);
		
	}

	public void HoldButton (Vector2 playerVelocity){
		
		Vector2 new_velocity = (Vector2)gameObject.transform.right * Time.deltaTime * 5f;
		//print (new_velocity);
		gameObject.transform.Translate (new_velocity);
		print(gameObject.transform.position.x);
		//gameObject.transform.position += transform.right * Time.deltaTime * 6f;
	}
}
