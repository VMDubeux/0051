using UnityEngine.SceneManagement;

public class PlayButton : Buttons
{
    public override void Click()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        base.Click();
    }
}