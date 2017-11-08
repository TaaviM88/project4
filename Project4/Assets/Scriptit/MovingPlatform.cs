using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject Platform;
    private CircleCollider2D _cc;
    private Vector3 _offset;
    int direction = 1;
    public bool movevertical = true;
	// Use this for initialization
	void Start () {
        if (movevertical == true)
        {
            _offset = Vector3.right * gameObject.GetComponent<BoxCollider2D>().size.y / 8;
        }
        else { _offset = Vector3.up * gameObject.GetComponent<BoxCollider2D>().size.y/8; }
	}
	
	// Update is called once per frame
	void Update () {
       
            transform.position = gameObject.transform.position + _offset * direction;
      
        //Invoke("DirectionChange",1f);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            //other.transform.SetParent(transform, false);

            // you can also do
             other.transform.parent = transform;
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
           
             other.transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DirectionChanger"))
        { DirectionChange();}
    }
    void DirectionChange()
    {
        direction *= -1;
    }

}
