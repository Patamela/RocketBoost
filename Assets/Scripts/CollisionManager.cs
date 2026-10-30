using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip explosionAudioClip;
    [SerializeField] private AudioClip landingAudioClip;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem explosionParticleSystem;
    [SerializeField] private ParticleSystem landingParticleSystem;

    AudioSource audioSource;
    PlayerHealth playerHealth;
    PlayerShooting playerShooting;
    PowerUpScriptableObject powerUp;

    float delay = 1f;
    bool isControllable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealth>();
        playerShooting = GetComponent<PlayerShooting>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!isControllable) return;

        switch (collision.gameObject.tag)
        {
            case "LaunchPad":
                Debug.Log("LaunchPad Collision Detected");
                break;
            case "LandingPad":
                ManageCollision(explosionAudioClip, landingParticleSystem);
                Invoke(nameof(LoadLevel), delay);
                break;
            case "Explosion":
                ManageCollision(landingAudioClip, explosionParticleSystem);
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Explosion")) return;
        playerHealth.LoseHealth();
    }

    /// <summary>
    /// Manages the collsion event by disabling palyer control,
    /// stopping any ongoing audio, playing the specified adio clip,
    /// playing the specified particle system,
    /// and disabling the layer movement.
    /// </summary>
    /// <param name="audioClip"></param>
    /// <param name="particleSystem"></param>
    private void ManageCollision(AudioClip audioClip, ParticleSystem particleSystem)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(landingAudioClip);
        particleSystem.Play();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ApplyPowerUp(PowerUpScriptableObject powerUpData)
    {
        if(powerUpData.PowerUpType == "Ammo")
        {
            playerShooting.RecoverAmmo();
        }
        else if(powerUpData.PowerUpType == "Health")
        {
           playerHealth.RecoverHealth(); 
        }
    }

}
