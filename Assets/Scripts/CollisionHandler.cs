using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay = 2.0f;
    [SerializeField] private AudioClip crashSFX;
    [SerializeField] private AudioClip successSFX;
    [SerializeField] private ParticleSystem successParticleVFX;
    [SerializeField] private ParticleSystem crashParticleVFX;

    AudioSource audioSource;

    bool isControllable = true;
    bool isCollidable = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollidable = !isCollidable;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!audioSource || !isControllable || !isCollidable) return;

        switch(collision.gameObject.tag)
        {
        case "Friendly":
            Debug.Log("Friendly");
            break;

        case "Finish":
            StartSuccessSequence();
            break;

        case "Fuel":
            Debug.Log("Fuel");
            break;

        default:
            StartCrashSequence();
            break;
        }
    }

    private void StartSuccessSequence()
    {
        // Movement 스크립트를 비활성화 합니다.
        Movement Mov = GetComponent<Movement>();
        if (Mov) Mov.enabled = false;
        // 현재 컨트롤중이 아니라고 설정합니다.
        isControllable = false;

        // 기존 사운드를 중지하고 성공 사운드를 재생합니다.
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);

        // 성공 파티클을 재생합니다.
        if (successParticleVFX) successParticleVFX.Play();

        Invoke("LoadNextLevel", levelLoadDelay);
    }

    private void StartCrashSequence()
    {
        // Movement 스크립트를 비활성화 합니다.
        Movement Mov = GetComponent<Movement>();
        if (Mov) Mov.enabled = false;
        // 현재 컨트롤중이 아니라고 설정합니다.
        isControllable = false;

        // 기존 사운드를 중지하고 충돌 사운드를 재생합니다.
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        
        // 충돌 파티클을 재생합니다.
        if (crashParticleVFX) crashParticleVFX.Play();

        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel()
    {
        // 현재 진행중인 레벨의 인덱스를 불러옵니다.
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        // 해당 인덱스의 레벨을 오픈합니다. (현재 Scene 리로드)
        SceneManager.LoadScene(currentSceneIdx);
    }

    private void LoadNextLevel()
    {
        // 현재 진행중인 레벨의 인덱스를 불러옵니다.
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;

        // 다음 레벨의 인덱스를 구하고, 해당 레벨이 유효한지 체크합니다.
        int nextSceneIdx = currentSceneIdx + 1;
        if (SceneManager.sceneCountInBuildSettings <= nextSceneIdx)
        {
            // 유효하지 않은 경우 인덱스를 0번(초기 레벨)으로 설정합니다.
            nextSceneIdx = 0;
        }

        // 다음 인덱스의 레벨을 오픈합니다.
        SceneManager.LoadScene(nextSceneIdx);
    }
}
