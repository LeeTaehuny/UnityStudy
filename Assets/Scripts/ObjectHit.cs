using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    // OnCollisionEnter() : 충돌 발생 시 호출되는 함수
    void OnCollisionEnter(Collision collision)
    {
        // GetComponent를 활용해 특정 오브젝트에 부착된 컴포넌트에 접근 가능
        GetComponent<MeshRenderer>().material.color = Color.black;
    }
}
