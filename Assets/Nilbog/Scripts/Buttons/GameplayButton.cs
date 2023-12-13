using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayButton : Buttons
{
    [Header("Menu Derrota:")]
    [SerializeField]
    private GameObject menu;

    public override void Click()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);

        base.Click();
    }
}
