using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    ParticleSystem particles;
    Renderer renderer;

    void Awake()
    {
        particles = GetComponent<ParticleSystem>();
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            particles.Play();
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            StartCoroutine(Die());
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Die());
        }

    }

    IEnumerator Die()
    {
        renderer.enabled = false;
        particles.Play();
        while(particles.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
