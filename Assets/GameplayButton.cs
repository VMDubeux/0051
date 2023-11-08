using UnityEditor.SceneManagement;
using UnityEngine;

public class GameplayButton : Buttons
{
    [Header("Menu Derrota:")]
    [SerializeField]
    private GameObject menu;

    public override void Click()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;
        EditorSceneManager.LoadScene(1);
        base.Click();
    }
}
