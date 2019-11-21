using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public ParticleSystem redParticles;
    public float particleRadius = 1f;
    public bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        redParticles = GetComponent<ParticleSystem>();
        ParticleSystem.ShapeModule shape = redParticles.shape;
        shape.radius = particleRadius;
    }
    // Update is called once per frame
    void Update()
    {
        ParticleSystem.ShapeModule shape = redParticles.shape;
        shape.radius = particleRadius;
        particleRadius += 0.01f;
    }

    public void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Gem"))
        {
            hit = true;
            Debug.Log("HIT");
        }
    }
}

