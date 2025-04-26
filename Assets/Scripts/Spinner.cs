using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    private Vector3 RotateVector;

    void Start()
    {
        
    }

    void Update()
    {
        // 오브젝트 회전 방법 : transform.Rotate(회전 벡터);
        transform.Rotate(RotateVector * Time.deltaTime);
    }
}
