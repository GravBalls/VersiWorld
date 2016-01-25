using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public bool IsAlive { get; set; }

	void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Target")
        {
            Target targetScript = other.gameObject.GetComponent<Target>();
            if(targetScript.IsHunter)
            {
                IsAlive = false;
            }
        }
    }
}
