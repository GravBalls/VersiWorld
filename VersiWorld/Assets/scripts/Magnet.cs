using UnityEngine;
using System.Collections;

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

    void Awake()
    {
        rend = GetComponent<Renderer>();
        rBody = GetComponent<Rigidbody>();
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
