using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButton : MonoBehaviour
{
    public void BackToMain()
    {
        GameManager.instance.InitGame();
        SceneManager.LoadScene(SceneName.MAIN_SCENE);
    }

}
