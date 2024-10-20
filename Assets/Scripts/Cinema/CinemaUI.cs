using TMPro;
using UnityEngine;

public class CinemaUI : MonoBehaviour
{
    [TextArea]
    public string[] dialogues;

    public TMP_Text dialogue_text;
    
    void SetDialogueText(int i)
    {
        if (i == -1) dialogue_text.text = "";
        else dialogue_text.text = dialogues[i];
    }
    
    void EndCinema()
    {
        GameManager.Instance.EndCinma();
    }
}
