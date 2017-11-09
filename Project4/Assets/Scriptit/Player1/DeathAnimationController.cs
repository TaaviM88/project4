using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimationController : MonoBehaviour {
    public float DeathTimer = 0.4f;
	// Use this for initialization
	void Start () {
        Invoke("DestroySelf",DeathTimer);
	}
	
	// Update is called once per frame
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
