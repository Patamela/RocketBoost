using UnityEngine;

public class EnemyCollisionManager : MonoBehaviour
{
    EnemyHealth enemyHealth;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter(Collider collider)
    {
        enemyHealth.LoseHealth();
    }
}
