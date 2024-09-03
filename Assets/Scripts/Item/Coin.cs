using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f;
    AudioSource audio;
    public GameObject coin;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(RotateCoin());
    }
    private IEnumerator RotateCoin()
    {
        while (true)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            yield return null; // 한 프레임을 기다립니다.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER))
        {
            StartCoroutine(GetCoin() );
        }
    }

    const int minCoin = 3;
    const int maxCoin = 6;
    IEnumerator GetCoin()
    {
        audio.Play();
        int randCoin = Random.Range(minCoin, maxCoin);
        GameManager.instance.Gold += randCoin;
        GameHUDManager.instance.SetGoldText();
        coin.SetActive(false);
        yield return new WaitForSeconds(Resources.Load<AudioClip>("Sounds/Coin").length);
        Destroy(gameObject);
    }
}
