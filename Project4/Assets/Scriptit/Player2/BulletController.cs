using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	public float speed = 7f;
	public float deathTimer = 2f;
	public int powerUpInt = 0;
	private Vector3 bulletMovement;
	private Vector3 bulletRotation;
	private Vector2 _currentPosition;
	public int chooseSide = 1;
	public int hshot = -1;
	public int vShot = 1;
	Vector2 positionOnScreen;
	Vector2 mouseOnScreen;
	Rigidbody2D _rb;
	public GameObject explosionprefab;
	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		//transform.position += bulletMovement;

		//transform.localRotation *= Quaternion.Euler(bulletRotation);
		_rb.AddForce(-1*transform.right * speed, ForceMode2D.Impulse);

	}
	void OnEnable()
	{
		switch (powerUpInt)
		{
		case 0:
			/*
			bulletMovement = -chooseSide*(Vector3.right) * speed * Time.deltaTime;
			bulletMovement = -chooseSide * (new Vector2(vShot, (0.5f * hshot) * chooseSide)) * speed * Time.deltaTime;
			bulletRotation = new Vector3(0, 0, 20 * speed * Time.deltaTime);*/
			//GetComponent<SpriteRenderer>().sprite = _SpPowerUp0;
			//GetComponent<CircleCollider2D>().radius = 0.05f;
			break;

		case 1:
			/*bulletMovement = Vector3.right * speed * Time.deltaTime;
			bulletRotation = new Vector3(0, 0, 5 * speed * Time.deltaTime);*/

			//GetComponent<SpriteRenderer>().sprite = _SpPowerUp1;
			//GetComponent<CircleCollider2D>().radius = 0.21f;
			break;

		case 2:
			/*bulletMovement = new Vector3(0.50f * speed * Time.deltaTime, 0.05f * (Mathf.Sin(2 * Mathf.PI * speed * Time.time)), 0);
			bulletRotation = new Vector3(0, 0, 5 * speed * Time.deltaTime);*/

			//GetComponent<SpriteRenderer>().sprite = _SpPowerUp2;
			//GetComponent<CircleCollider2D>().radius = 0.21f;
			break;
		default:

			break;
		}
		Invoke("Destroy", deathTimer);
	}

	/*void Destroy()
	{
		GameObject explosion = GameObject.Instantiate(explosionprefab);
		explosion.transform.position = this.transform.position;
		//Instantiate(explosion,transform.parent.position);
		gameObject.SetActive(false);
	}*/
	void OnDisable()
	{
		CancelInvoke();
	}

	/*private void OnCollisionEnter2D(Collision2D coll)
	{
		// if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Obstacle")
		if(coll.gameObject.tag == "CameraCollision" || coll.gameObject.tag == "Obstacle")
		{
			Destroy();
		}
	}*/

}
