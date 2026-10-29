using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float bulletLifeTime = 1f;

    void OnEnable()
    {   
        // Start the bullet lifetime countdown
        Invoke(nameof(Deactivate), bulletLifeTime);
    }

    /// <summary>
    /// Desactivates the bullet
    /// </summary>
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        //Deactivate the bullet when it coolides with another object
        Deactivate();

        //TODO: Particles
        //TODO: if bullet hits an enemy, reduce enemy health
        //TODO: if bullet hits obstacle, destroy obstacle
        //TODO: if bullet hits player, reduce player health
    }
}
