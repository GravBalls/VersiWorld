using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Target")
        {
            Debug.Log("hit");
        }
    }
}
