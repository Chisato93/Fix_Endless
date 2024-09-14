using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    private Dictionary<SceneType, ISceneLoader> _sceneLoaders = new Dictionary<SceneType, ISceneLoader>();

    protected override void Awake()
    {
        _sceneLoaders.Add(SceneType.Main, new MainSceneLoader());
        _sceneLoaders.Add(SceneType.Game, new GameSceneLoader());
        _sceneLoaders.Add(SceneType.Shop, new ShopSceneLoader());
        _sceneLoaders.Add(SceneType.Cinema, new CinemaSceneLoader());
    }

    public void LoadScene(SceneType type)
    {
        if (_sceneLoaders.ContainsKey(type))
            _sceneLoaders[type].LoadScene();
    }
}

public interface ISceneLoader
{
    void LoadScene();
}

public class MainSceneLoader : ISceneLoader
{
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName.MAIN_SCENE, LoadSceneMode.Single);
    }
}

public class GameSceneLoader : ISceneLoader
{
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName.GAME_SCENE, LoadSceneMode.Single);
    }
}
public class ShopSceneLoader : ISceneLoader
{
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName.SHOP_SCENE, LoadSceneMode.Additive);
    }
}

public class CinemaSceneLoader : ISceneLoader
{
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName.CINEMA_SCENE, LoadSceneMode.Additive);
    }
}