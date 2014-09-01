﻿using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    [Tooltip("Prefab of explosion effect.")]
    public GameObject explosion;


    void Start()
    {
        // Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
        Destroy(gameObject, 2);
    }

    void Awake()
    {
        GetComponent<Vitality>().Register(OnTakeDamage, OnDeath);
    }

    private void OnTakeDamage(GameObject enemy)
    {
        // Rockets shouldn't take damage.
    }

    private void OnDeath()
    {
        // Instantiate the explosion and destroy the rocket.
        OnExplode();
        Destroy(gameObject);
    }

    public void OnExplode()
    {
        // Create a quaternion with a random rotation in the z-axis.
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate the explosion where the rocket is with the random rotation.
        Instantiate(explosion, transform.position, randomRotation);
    }
}
