using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Ending_TimeLine : MonoBehaviour
{
    
    public GameObject timeline;

    public void OpenTimeLine()
    {
        timeline.SetActive(true);
        PlayableDirector dir = timeline.GetComponent<PlayableDirector>();
        dir.Play();
    }
}
