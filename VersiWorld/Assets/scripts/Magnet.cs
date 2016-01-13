using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour
{
    public float force;

    //BoxCollider magnetTrigger = new BoxCollider();

    void Start()
    {
        
    }

    void OnDrawGizmos()
    {
        Vector3 position = transform.position;
        position.y = 0;
        //transform.position = position;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(position, transform.lossyScale);
    }

    void OnTriggerStay(Collider other)
    {   
        if(other.tag == "Player")
        {
            Vector3 direction = Vector3.Normalize(transform.position - other.transform.position);
            other.GetComponent<Rigidbody>().AddForce(direction * force * Time.fixedDeltaTime);
            Debug.Log(direction);
        }
    }

}
