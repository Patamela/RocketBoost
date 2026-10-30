using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosiveObject : MonoBehaviour
{   
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] ParticleSystem explosiveParticle;

    PlayerHealth playerHealth;

    public void Detonate()
    {   
        
        StartCoroutine(ExplosionParticles());

        Collider[] playerCollider = Physics.OverlapSphere(transform.position, explosionRadius, playerLayer);

        foreach(Collider hit in playerCollider)
        {
            if (hit != null)
            {
                playerHealth = hit.GetComponent<PlayerHealth>();
                break;
            }
        }

        if(playerHealth != null) playerHealth.LoseHealth();
        
    }

    IEnumerator ExplosionParticles()
    {   
        explosiveParticle.Play();
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }


}
