using UnityEngine;
using System.Collections;

public class SpringScript : CommandParent {

    public Vector3 bounceDirection = new Vector3(0, 1, 0);
    public float bounceForce = 10;
    public bool isActivatable = false;

    int maxActiveFrames = 10;
    int curActiveFrames = 0;
    bool isActive = false;

    Rigidbody colidedObject = null;//this causes some really dumb behavior but it mostly works for now

	// Use this for initialization
	void Start () {
        bounceDirection.Normalize();

        if (isActivatable) {
            actionDescription = "Activate Spring";
        }
        else
        {
            isActive = true;
        }
	}


    // Update is called once per frame
    void FixedUpdate () {
        if (isActivatable) {
            if (isActive)
            {
                curActiveFrames++;
                if (curActiveFrames > maxActiveFrames)
                {
                    isActive = false;
                }
            }
        }
    }

    public override void Activate()
    {
        if (isActivatable)
        {
            isActive = true;
            curActiveFrames = 0;
            if (colidedObject != null)
            {
                colidedObject.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
                colidedObject = null;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isActive)
        {
            collision.rigidbody.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
        else
        {
            colidedObject = collision.rigidbody;
        }
    }

}
