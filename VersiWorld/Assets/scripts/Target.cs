using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    ParticleSystem particles;
    new Renderer renderer;
    Rigidbody rBody;

    public bool IsHunter
    {
        get
        {
            return isHunter;
        }

        set
        {
            isHunter = value;
            if(isHunter)
            {
                renderer.material = hunterMaterial;
            }
            else
            {
                renderer.material = defaultMaterial;
            }
        }
    }

    bool isHunter;

    [Tooltip("Max timer target is in hunter mode.")]
    public float maxHuntTime;
    float hunterTimer;

    public Material defaultMaterial;
    public Material hunterMaterial;

    void Awake()
    {
        particles = GetComponent<ParticleSystem>();
        renderer = GetComponent<Renderer>();
        rBody = GetComponent<Rigidbody>();
        IsHunter = false;
    }
    void Update()
    {
     if(isHunter)
        {
            if (hunterTimer < maxHuntTime)
            {
                hunterTimer += Time.deltaTime;
            }
            else
            {
                hunterTimer = 0;
                IsHunter = false;
            }

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

        if(other.gameObject.tag == "Obstacle")
        {
            IsHunter = true;
        }

    }

    IEnumerator Die()
    {
        renderer.enabled = false;
        Kernal.targets.Remove(this);
        particles.Play();
        while (particles.isPlaying)
        {
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
