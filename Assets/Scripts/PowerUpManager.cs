using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private PowerUpScriptableObject powerUpData;
    [SerializeField] private ParticleSystem powerUpEffect;

    CollisionManager collisionManager;

    void Start()
    {
        collisionManager = FindAnyObjectByType<CollisionManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        collisionManager.ApplyPowerUp(powerUpData);
        StartCoroutine(PowerUpParticle());
    }

    IEnumerator PowerUpParticle()
    {
        powerUpEffect.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
