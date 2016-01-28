using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public bool IsAlive { get; set; }

    new Renderer renderer;
    ParticleSystem particles;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        particles = GetComponentInChildren<ParticleSystem>();
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
        particles.Play();
        while(particles.isPlaying)
        {
            yield return null;
        }
        IsAlive = false;
        Destroy(gameObject);
    }
}
