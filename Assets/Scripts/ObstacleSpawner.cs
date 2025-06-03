using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        }
    }
}
