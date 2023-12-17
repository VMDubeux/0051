using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTwo : Buttons
{
    [SerializeField]
    [Header("Menu Vit�ria")]
    private GameObject menu;
    

    public override void Click()
    {
        menu.SetActive(false);
        SceneManager.LoadScene(4, LoadSceneMode.Single);

        base.Click();
    }
}
