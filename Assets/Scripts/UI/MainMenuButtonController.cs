using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] private GameObject shopObject;
    [SerializeField] private SettingPanel settingPanel;

    public void OnStartButtonClicked()
    {
        // TODO => 로딩창 만들기
        SoundController.Instance.SetBgm(SceneName.GAME_SCENE);
        SceneManager.LoadSceneAsync(SceneName.GAME_SCENE);
    }

    public void OnCinemaButtonClicked()
    {
        Debug.Log("Cinema Scene");
        // 상점 메뉴 로직
    }
    public void OnShopButtonClicked()
    {
        Debug.Log("Shop Open");
        // 상점 메뉴 로직
    }

    public void OnSettingsButtonClicked()
    {
        GameObject settingObject = settingPanel.gameObject;

        if (!settingObject.activeSelf)
            settingPanel.ActiveOn();
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
