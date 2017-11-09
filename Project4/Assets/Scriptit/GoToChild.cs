using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToChild : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Platform")
        {
            //other.transform.SetParent(transform, false);

            // you can also do
            //transform.parent.rotation = col.transform.rotation;
            
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Platform")
        {

            transform.parent = null;
        }
    }
}
