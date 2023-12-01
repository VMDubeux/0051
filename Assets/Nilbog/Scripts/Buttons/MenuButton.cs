using UnityEngine.SceneManagement;

public class MenuButton : Buttons
{
    public override void Click()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        base.Click();
    }
}
