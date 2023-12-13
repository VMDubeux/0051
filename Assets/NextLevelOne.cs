using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelOne : Buttons
{
    [SerializeField]
    [Header("Menu Vit�ria")]
    private GameObject menu;
    

    public override void Click()
    {
        menu.SetActive(false);
        SceneManager.LoadScene(2, LoadSceneMode.Single);

        base.Click();
    }
}
