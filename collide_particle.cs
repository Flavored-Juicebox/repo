using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide_particle : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    private bool particleDestroy;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (particleDestroy)
        {
            GameObject particle = Instantiate(particles, transform.position - new Vector3(0f, 0.8f, 0f), Quaternion.identity) as GameObject;
            ParticleSystem particleComponent = particle.GetComponent<ParticleSystem>();
            float totalDuration = particleComponent.duration + particleComponent.startLifetime;
            Destroy(particle, totalDuration);

            particleDestroy = !particleDestroy;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        particleDestroy = !particleDestroy;
    }
}
