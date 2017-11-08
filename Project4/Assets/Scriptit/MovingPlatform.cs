using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
   /* public GameObject Platform;
    private CircleCollider2D _cc;
    private Vector3 _offset;
	// Use this for initialization
	void Start () {
        _offset = Vector3.up * Platform.GetComponent<BoxCollider2D>().size.y / 8;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Platform.transform.position + _offset;
	}*/
    public GameObject _wheel;
    private CircleCollider2D _cc;
    private Vector3 _offset;
    void Start()
    {
        _offset = Vector3.up * _wheel.GetComponent<CircleCollider2D>().radius / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _wheel.transform.position + _offset;
    }
}
