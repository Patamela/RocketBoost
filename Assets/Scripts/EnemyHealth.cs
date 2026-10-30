using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] ParticleSystem explosionEnemyParticle;

    public void LoseHealth()
    {   
        maxHealth--;
        
        if(maxHealth<=0)
        {   
            StartCoroutine(ExplosionParticles());
        }
        
        Debug.Log($"Enemigo Vida: {maxHealth}");
    }

    IEnumerator ExplosionParticles()
    {   
        explosionEnemyParticle.Play();
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
