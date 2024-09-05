using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    public void ActiveOn()
    {
        this.gameObject.SetActive(true);
    }
    public void ActiveOff()
    {
        this.gameObject.SetActive(false);
    }
}
