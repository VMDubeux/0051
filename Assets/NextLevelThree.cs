using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelThree : Buttons
{
    [SerializeField]
    [Header("Menu Vit�ria")]
    private GameObject menu;
    

    public override void Click()
    {
        menu.SetActive(false);
        SceneManager.LoadScene(0, LoadSceneMode.Single);

        base.Click();
    }
}
