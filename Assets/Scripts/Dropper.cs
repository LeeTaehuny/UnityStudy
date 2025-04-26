using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Dropper : MonoBehaviour
{
    [SerializeField]
    private float TimeToWait = 3.0f;

    private MeshRenderer MeshRendererCache;
    private Rigidbody RigidbodyCache;
    
    void Start()
    {
        MeshRendererCache = GetComponent<MeshRenderer>();
        RigidbodyCache = GetComponent<Rigidbody>();
        if (MeshRendererCache) MeshRendererCache.enabled = false;
        if (RigidbodyCache) RigidbodyCache.useGravity = false;
    }

    void Update()
    {
        // Time.time : 게임 시작 이후 경과 시간을 보여주는 변수
        if (Time.time > TimeToWait)
        {
            if (MeshRendererCache) MeshRendererCache.enabled = true;
            if (RigidbodyCache) RigidbodyCache.useGravity = true;
        }
    }
}
