using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public delegate void ButtonClick();
    public static event ButtonClick OnButtonClick;

    void Update()
    {
        OnButtonClick?.Invoke();
    }

    private void OnDestroy()
    {
        OnButtonClick = null;
    }
}
