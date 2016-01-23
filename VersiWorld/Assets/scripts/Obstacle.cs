using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    ParticleSystem particles;
    new Renderer renderer;
    Rigidbody rBody;
    bool isHunter = false;

    void Awake()
    {
        particles = GetComponent<ParticleSystem>();
        renderer = GetComponent<Renderer>();
        rBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            particles.Play();
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            StartCoroutine(Die());
        }
    }

    void FixedUpdate()
    {
        if(Vector3.Magnitude(rBody.velocity) < .1f)
        {
            rBody.AddForce(Vector3.Normalize(-Physics.gravity) * 15, ForceMode.Impulse );
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isHunter)
            {
                StartCoroutine(Die());
            }

        }

    }

    IEnumerator Die()
    {
        renderer.enabled = false;
        particles.Play();
        while (particles.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
