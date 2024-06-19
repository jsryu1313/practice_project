using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStage3WithMKey : MonoBehaviour
{
    void Update()
    {
        // M 키 입력 감지
        if (Input.GetKeyDown(KeyCode.M))
        {
            // "Stage3" 씬으로 이동
            SceneManager.LoadScene("Stage3");
        }
    }
}
