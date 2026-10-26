using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //1º Interfaz, 2º Componentes, 3º Variables Internas

    [Header("Input Actions")]
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;

    [Header("Movement Settings")]
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float rotationForce = 2.5f;

    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem thrustParticleSystem;
    [SerializeField] private ParticleSystem leftThrustParticleSystem;
    [SerializeField] private ParticleSystem rightThrustParticleSystem;
    
    [Header("Audio Settings")]
    [SerializeField] private AudioClip thrustAudioClip;

    Rigidbody rb;
    AudioSource audioSource;

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
   private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void ProcessRotation()
    {
        rb.freezeRotation = true; //freezinfn rotation so we can manually rotate

        float rotationValue = rotation.ReadValue<float>();

        if(rotationValue < 0)
        {
            RotateRight();
        }
        else if (rotationValue > 0)
        {
            RotateLeft();
        }
        else
        {
            StopRotation();
        }
    }

    private void RotateRight()
    {
        transform.Rotate(Vector3.forward * rotationForce);
        if (!rightThrustParticleSystem.isPlaying)
        {
            leftThrustParticleSystem.Stop();
            rightThrustParticleSystem.Play();
        }
    }

    private void RotateLeft()
    {
        transform.Rotate(Vector3.back * rotationForce);
        if (!leftThrustParticleSystem.isPlaying)
        {
            rightThrustParticleSystem.Stop();
            leftThrustParticleSystem.Play();
        }
    }

    private void StopRotation()
    {
       leftThrustParticleSystem.Stop();
       rightThrustParticleSystem.Stop();
    }

    private void StopThrusting()
    {
        thrustParticleSystem.Stop();
        audioSource.Stop();
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * moveForce);

        if (!thrustParticleSystem.isPlaying)
        {
            thrustParticleSystem.Play();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustAudioClip);
        }
    }
}
