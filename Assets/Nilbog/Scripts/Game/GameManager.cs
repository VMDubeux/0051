using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    internal SceneManaging sceneManaging;

    internal Objects LastSelected;
    internal Objects CurrentSelected;

    private void Start()
    {
        UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;
        Inventory.instance.AddImage(Inventory.instance.SetUpSprite);

        LastSelected = null;
        CurrentSelected = null;

        Time.timeScale = 1.0f;

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
