using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        // 레벨에 배치되어 있는 Music Player의 수를 체크합니다.
        int numOfMusicPlayer = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

        // 만약 1개가 넘는다면?
        if (numOfMusicPlayer > 1)
        {
            // 해당 오브젝트를 소멸시킵니다.
            Destroy(gameObject);
        }
        else
        {
            // 레벨을 로드할 때 해당 오브젝트를 소멸시키지 않습니다.
            DontDestroyOnLoad(gameObject);
        }
    }
}
