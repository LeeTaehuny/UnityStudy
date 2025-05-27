using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        // 코루틴을 시작합니다.
        StartCoroutine(ReloadLevelRoutine());
    }

    public IEnumerator ReloadLevelRoutine()
    {
        // yield return은 기존 retrun과 다르게 특정 시간동안 멈췄다가 이어서 실행하라는 의미
        yield return new WaitForSeconds(1.0f);

        // 1.0f초가 지난 뒤 실행되는 코드
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
}
