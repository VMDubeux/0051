using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public delegate void ButtonClick();
    public static event ButtonClick OnButtonClick;

    void Update()
    {
        if (OnButtonClick != null)
            OnButtonClick();
    }
}
