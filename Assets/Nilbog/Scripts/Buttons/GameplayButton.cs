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
        sceneNumber = SceneManaging.Instance.scene.buildIndex;
    }

    public override void Click()
    {
        menu.SetActive(false);
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);

        base.Click();
    }
}
