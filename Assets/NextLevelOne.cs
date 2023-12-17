using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelOne : Buttons
{
    [SerializeField]
    [Header("Menu Vitória")]
    private GameObject menu;
    

    public override void Click()
    {
        menu.SetActive(false);
        SceneManager.LoadScene(3, LoadSceneMode.Single);

        base.Click();
    }
}
