public class PlayButton : Buttons
{
    private void Update()
    {
        currentButton.onClick.AddListener(() => ButtonsManager.OnButtonClick += Click);
    }

    public override void Click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}