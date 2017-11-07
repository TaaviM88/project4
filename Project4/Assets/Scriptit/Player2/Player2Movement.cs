using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Player2MoveHorizontal");

		Vector2 movement = new Vector2 (moveHorizontal, 0f);

		rb2d.AddForce (movement * speed);
	}
}
