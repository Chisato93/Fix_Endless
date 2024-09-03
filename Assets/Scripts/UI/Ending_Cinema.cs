using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_Cinema : MonoBehaviour
{
    void BackToMain()
    {
        SceneManager.LoadScene(SceneName.MAIN_SCENE);
    }
}
