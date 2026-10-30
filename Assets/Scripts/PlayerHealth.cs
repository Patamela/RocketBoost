using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;

    int currentHealth;
    bool isVulnerable = true;
    float waitTime = 2f;
    float delay = 1f;

    public int CurrentHealth 
    {
        get { return currentHealth; } 
        set { if(currentHealth > 3) currentHealth = 3; else currentHealth = value; }
    }

    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void LoseHealth()
    {
        if(!isVulnerable) return;

        CurrentHealth--;

        if(CurrentHealth<=0) Invoke(nameof(GameOver),delay);

        if(isVulnerable) StartCoroutine(Invulnerable());

        Debug.Log($"Vida Jugador: {CurrentHealth}");
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void RecoverHealth()
    {
        CurrentHealth = maxHealth;
    }

    IEnumerator Invulnerable()
    {
        isVulnerable = false;
        yield return new WaitForSeconds(waitTime);
        isVulnerable = true;
    }
}
