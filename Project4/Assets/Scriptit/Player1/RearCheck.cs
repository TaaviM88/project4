using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearCheck : MonoBehaviour {
    float distance = 0.1f;
	// Use this for initialization
    public LayerMask groundLayer;

  public bool IsGrounded()
    {

        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
  
        return false;
    }
	// Update is called once per frame
	/*void Update () {
		
	}*/
}
