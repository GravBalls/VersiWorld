using UnityEngine;
using System.Collections;
using System;

public class Magnet : MonoBehaviour
{
    public float force;

    public bool Activated
    {
        get
        {
            return isActivated;
        }

        set
        {
            isActivated = value;
            if(isActivated)
            {
                rend.material.SetColor("_EmissionColor", Color.yellow);
            }
            else
            {
                rend.material.SetColor("_EmissionColor", Color.black);
            }
        }

    }


    bool isActivated;
    Renderer rend;
    Rigidbody rBody;
    BoxCollider triggerCollider;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        rBody = GetComponent<Rigidbody>();
        Activated = true;

        BoxCollider[] colliders = GetComponents<BoxCollider>();
        foreach (BoxCollider box in colliders)
        {
            if(box.isTrigger)
            {
                triggerCollider = box;
            }

        }
        Debug.Assert(triggerCollider != null, "could not find box collider trigger.");       

        SizeTrigger();
   
    }

    void Update()
    {
        Debug.DrawRay(transform.position, -transform.up, Color.red);
    }

    private void SizeTrigger()
    {
        RaycastHit hit;
        Vector3 startPosition = transform.position - Vector3.up * (transform.lossyScale.y / 2);
        if(Physics.Raycast(transform.position, -transform.up, out hit))
        {
            //y is ray distance / transform.scale.y -> it's scaled by transform so need to account for
            float y = hit.distance / transform.lossyScale.y;
            //center is in relation to the transform
            Vector3 center = -Vector3.up * hit.distance * 2;
            triggerCollider.size = new Vector3(1, y, 1);
            triggerCollider.center = center;
        }
    }

    void OnTriggerStay(Collider other)
    {   
        if(isActivated && other.tag == "Player")
        {
            Vector3 direction = Vector3.Normalize(transform.position - other.transform.position);
            other.GetComponent<Rigidbody>().AddForce((direction * force * Time.fixedDeltaTime) + rBody.velocity);
        }
    }

}
