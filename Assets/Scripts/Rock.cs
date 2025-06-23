using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] AudioSource collisionAudioSource;
    [SerializeField] float shakeModifier = 10.0f;
    [SerializeField] float cooldownTimer = 1.0f;

    CinemachineImpulseSource cinemachineImpulseSource;
    float collisionTimer = 0.0f;

    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (collisionTimer < cooldownTimer) return;

        FireImpluse();
        CollisionFX(other);

        collisionTimer = 0.0f;
    }

    private void FireImpluse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1.0f / distance) * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1.0f);
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    private void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;

        collisionParticleSystem.Play();
        collisionAudioSource.Play();
    }
}
