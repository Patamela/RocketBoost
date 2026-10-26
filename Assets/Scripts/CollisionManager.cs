using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip explosionAudioClip;
    [SerializeField] private AudioClip landingAudioClip;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem explosionParticleSystem;
    [SerializeField] private ParticleSystem landingParticleSystem;

    AudioSource audioSource;

    bool isControllable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
                ManageCollision(landingAudioClip);
                break;
            case "Explosion":
                ManageCollision(explosionAudioClip);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Manages the collsion event by disabling palyer control,
    /// stopping any ongoing audio, playing the specified adio clip,
    /// playing the specified particle system,
    /// and disabling the layer movement.
    /// </summary>
    /// <param name="audioClip"></param>
    private void ManageCollision(AudioClip audioClip)
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(landingAudioClip);
        GetComponent<PlayerMovement>().enabled = false;
    }
}
