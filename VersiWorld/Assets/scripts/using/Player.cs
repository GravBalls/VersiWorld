using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public bool IsAlive { get; set; }

    new Renderer renderer;
    ParticleSystem particles;
    new SphereCollider collider;
    Rigidbody rbody;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        particles = GetComponentInChildren<ParticleSystem>();
        collider = GetComponent<SphereCollider>();
        rbody = GetComponent<Rigidbody>();
        IsAlive = true;
    }

	void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Target")
        {
            Target targetScript = other.gameObject.GetComponent<Target>();
            if(targetScript.IsHunter)
            {
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator Die()
    {
        renderer.enabled = false;
        collider.enabled = false;
        rbody.detectCollisions = false;
        particles.Play();
        while(particles.isPlaying)
        {
            yield return null;
        }
        IsAlive = false;
        Destroy(gameObject);
    }
}
