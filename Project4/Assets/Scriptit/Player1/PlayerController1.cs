using System.Collections;
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
            }
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
            _speed = 0;
        }
        if (Input.GetAxis("Fire1") > 0 && _grounded == true && _canMove == true)
        {
            if (_rb.velocity.y == 0)
            {
                _rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
                _grounded = false;
                _jumping = true;
                //anime.SetInteger("State", 3);
                
                //aktivoi tämä kun haluat hyppyäänen
                //source.PlayOneShot(JumpSound);
            }

        }

        if (!_rearCheck.IsGrounded() &&_jumping ==false)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
            _angle++;
        }
        if(!_frontCheck.IsGrounded() && _jumping ==false)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
            _angle--;
        }
      
        

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
            _canMove = false;
            //anime.Play("PlayerDeath");
            //anime.SetInteger("State", 3);
            Invoke("GoToCheckpoint", 0.3f);

            //GoToCheckpoint();
            //Debug.Log("Spawnasin perkele");
        }

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
