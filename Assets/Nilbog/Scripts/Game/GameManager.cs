#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ObjTeleport objTeleport;

    internal Objects LastSelected;
    internal Objects CurrentSelected;

    private void Awake()
    {
        Time.timeScale = 1.0f;

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }
}
