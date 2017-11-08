﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {
    public float _jumpForce = 4.8f;
    public float Speed = 3f, RunSpeed = 1;
    private float _speed;
    private Rigidbody2D _rb;
    public Transform SpawnPoint;
    private bool _grounded, _jumping, _facingRight = true;
    private Vector3 latestCheckpoint;
    public AudioClip JumpSound;
    public AudioClip DeathSound;
    private AudioSource source;
    private Transform GroundCheck, CeilingCheck;
    RearCheck _rearCheck;
    FrontCheck _frontCheck;
    const float groundedRadius = 0.1f, ceilingRadius = 0.1f;
    private CircleCollider2D ccollider;
    [SerializeField]
    private LayerMask whatIsGround;
    bool _canMove;
    private float _playerAngle = 0f;
    private float _angle = 0;
    private float _minAngle = -25f;
    private float _maxAngle = 25f;
    public bool _canrotate = true;
	// Use this for initialization
	void Start () {
		GroundCheck = transform.Find("GroundCheck");
        CeilingCheck = transform.Find("CeilingCheck");
        _rb = GetComponent<Rigidbody2D>();
        _canMove = true;
        _speed = _rb.velocity.x;
        source = GetComponent<AudioSource>();
        ccollider = GetComponent<CircleCollider2D>();
        _rearCheck = GetComponentInChildren<RearCheck>();
        _frontCheck = GetComponentInChildren<FrontCheck>();
        _angle = _playerAngle;
        latestCheckpoint = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
        /*Vector2 direction = Vector2.down;
        Vector2 position = transform.position;
        float distance = 3000.0f;
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, whatIsGround);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));*/

            //_angle = _playerAngle;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _grounded = true;
                _jumping = false;
            }
            else { _jumping = true; _grounded = false; }
        }
        if (Input.GetAxis("Horizontal") > 0 && _canMove == true)
        {
            if (_facingRight == false)
            {
                Flip();
            }
           _rb.velocity = new Vector2(Speed * RunSpeed, _rb.velocity.y);
            _speed = _rb.velocity.x;
        }
        if (Input.GetAxis("Horizontal") < 0 && _canMove == true)
        {
            //transform.Translate(new Vector3(-1*Speed * Time.deltaTime, 0, 0));
            if (_facingRight == true)
            {
                Flip();
            }
            _rb.velocity = new Vector2(-1 * Speed * RunSpeed, _rb.velocity.y);
            _speed = _rb.velocity.x;
            //playerRigidbody2D.velocity = new Vector2(-1 * Speed, 0);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            _rb.velocity = new Vector2(0,_rb.velocity.y);
        }
        if (Input.GetAxis("Fire1") > 0 && _grounded == true && _canMove == true)
        {
            //transform.position = new Vector2(_rb.velocity.x, Speed * Time.deltaTime);
            if (_frontCheck.IsGrounded())
            {
                _rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
                _grounded = false;
                _jumping = true;
                //anime.SetInteger("State", 3);
                
                //aktivoi tämä kun haluat hyppyäänen
                //source.PlayOneShot(JumpSound);
            }

        }

        if (_canrotate == true)
        {
            if (!_frontCheck.IsGrounded() || !_rearCheck.IsGrounded())
            {
                if (!_frontCheck.IsGrounded() && _jumping == false)
                {
                    Debug.Log("Ei osu maahan");
                    if (_facingRight)
                    {
                        _angle--;
                    }
                    else { _angle++; }
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
                    //transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(_angle, _minAngle, _maxAngle)));
                }

                if (!_rearCheck.IsGrounded() && _jumping == false)
                {
                    Debug.Log("Perser ei osu maahan");
                    if (_facingRight)
                    {
                        _angle++;
                    }
                    else { _angle--; }
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
                    //transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(_angle, _minAngle, _maxAngle)));
                }
                //if (_angle <= -45 || _angle >= 45) { _angle = _playerAngle; }
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
            }
        }
        Debug.Log("Jump" +_jumping);
        Debug.Log("Grounded " +_grounded);

        /*if (_rearCheck.IsGrounded() && _frontCheck.IsGrounded())
        {
            _jumping = false;
        }*/
	}

        //playerRigidbody2D.velocity = new Vector2(Speed, playerRigidbody2D.velocity.y);

    void OnCollisionEnter2D(Collision2D col)
    {
        /*if (col.gameObject.tag == "ground") //&& playerRigidbody2D.velocity.y == 0)
        {
            _grounded = true;
            _jumping = false;
        }*/
        if (col.gameObject.tag == "KillAxel")
        {
            //_canMove = false;
            //anime.Play("PlayerDeath");
            //anime.SetInteger("State", 3);
            Invoke("GoToCheckpoint", 0.3f);

            //GoToCheckpoint();
            //Debug.Log("Spawnasin perkele");
        }
        if (col.gameObject.tag == "MovingPlatform")
        {
            //transform.parent = col.transform;
            return;
        }
       

    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "MovingPlatform")
        {
            //transform.parent = null;
            return;
        }
    }
    void OnTriggerEnter2D(Collider2D col) 
        {
            if (col.gameObject.CompareTag("Checkpoint"))
            { updateCheckpoint(); }
        }

    void updateCheckpoint()
    {
        latestCheckpoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void GoToCheckpoint()
    {
        //_canMove = true;
       // Invoke("EnablePlayerControls", 0.3f);
        transform.position = latestCheckpoint;
        /*GameObject obj = GameObject.FindGameObjectWithTag("MainCamera");
        obj.gameObject.SendMessage("GoToPlayer");*/
    }
    void EnablePlayerControls()
    {
        _canMove = true;
    }
    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}
