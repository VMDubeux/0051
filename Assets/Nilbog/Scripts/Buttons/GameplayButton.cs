using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

public class GameplayButton : Buttons
{
    [Header("Menu Derrota:")]
    [SerializeField]
    private GameObject menu;

    public override void Click()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;

#if UNITY_EDITOR
        EditorSceneManager.LoadScene(1);
#endif

        base.Click();
    }
}
