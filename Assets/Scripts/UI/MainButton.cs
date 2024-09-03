using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public void GameStart()
    {
        GameManager.instance.FirstGame = false;
        DataManager.instance.SaveData();
        GameManager.instance.InitGame();
        SceneManager.LoadScene(SceneName.GAME_SCENE);
    }


    public void ShowCutScene()
    {
        GameManager.instance.StartCinema();
    }

    public GameObject shop;
    private float closeTime = 3f;
    public void OpenItemShop()
    {
        StartCoroutine(Shop_Co());

    }

    IEnumerator Shop_Co()
    {
        shop.SetActive(true);
        yield return new WaitForSeconds(closeTime);
        shop.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }    
}
