using System;
using UnityEngine;
using UnityEngine.InputSystem; //read doc zora

public class Movement : MonoBehaviour
{
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction Rotation;
    [SerializeField] private float rotationStrength = 100f;
    [SerializeField] private float thrustStrength = 100f; //named it thurst it takes input action to thurst
    [SerializeField] private AudioClip mainEngine;
    [SerializeField] private ParticleSystem mainEngineParticles;
    [SerializeField] private ParticleSystem rightEngineParticles;
    [SerializeField] private ParticleSystem leftEngineParticles;
    
    private Rigidbody rb;
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        thrust.Enable();
        Rotation.Enable();
    }

    private void FixedUpdate()
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
    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }

        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }
    private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }
    
    private void ProcessRotation()
    {
        float rotationInput = Rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            RotateRight();
        }
        else if (rotationInput > 0)
        {
            RotateLeft();
        }
        else
        {
            StopRotating();
        }
    }
    private void RotateRight()
    {
        ApplyRotation(rotationStrength);
        if (!rightEngineParticles.isPlaying)
        {
            leftEngineParticles.Stop();
            rightEngineParticles.Play();
        }
    }
    private void RotateLeft()
    {
        ApplyRotation(-rotationStrength);
        if (!leftEngineParticles.isPlaying)
        {
            rightEngineParticles.Stop();
            leftEngineParticles.Play();
        }
    }
    private void StopRotating()
    {
        rightEngineParticles.Stop();
        leftEngineParticles.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
