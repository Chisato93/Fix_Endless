using System.Collections;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{
    AudioSource audio;
    GameObject go;

    const int oxygen_amount =30;

    private void Awake()
    {
        go = transform.GetChild(0).gameObject;
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER))
        {
            StartCoroutine(GetOxygen());
        }
    }

    IEnumerator GetOxygen()
    {
        audio.Play();
        go.SetActive(false);
        GameManager.instance.GetBreathe(oxygen_amount);
        yield return new WaitForSeconds(Resources.Load<AudioClip>("Sounds/Breathe").length);
        Destroy(gameObject);
    }
}
