using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] laserObjects;

    bool isFire = false;

    void Update()
    {
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in laserObjects)
        {
            ParticleSystem particleSystem = laser.GetComponent<ParticleSystem>();
            if (particleSystem)
            {
                var emissionModule = particleSystem.emission;
                emissionModule.enabled = isFire;
            }
        }
    }

    public void OnFire(InputValue Value)
    {
        isFire = Value.isPressed;
    }
}
