using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    const string playerString = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected void Update()
    {
        transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
    }

    protected abstract void OnPickup();
}
