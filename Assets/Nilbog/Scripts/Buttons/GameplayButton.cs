using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayButton : Buttons
{
    [Header("Menu Derrota:")]
    [SerializeField]
    private GameObject menu;

    private int sceneNumber;

    private void Start()
    {
        sceneNumber = GameManager.Instance.actualScene;
    }

    public override void Click()
    {
        menu.SetActive(false);
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);

        base.Click();
    }
}
