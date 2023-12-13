using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManaging : MonoBehaviour
{
    public static SceneManaging Instance;

    public delegate void Level();
    public static event Level OnLevel;

    internal Scene scene;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (OnLevel != null)
            OnLevel();
    }

    public void VictoryChangeScene()
    {
        int sceneIndex = scene.buildIndex + 1;
        StartCoroutine(WaitTime());
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void VictoryChangeSceneToMainMenu()
    {
        int sceneIndex = 0;
        StartCoroutine(WaitTime());
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void DefeatReloadScene()
    {
        int sceneIndex = scene.buildIndex;
        StartCoroutine(WaitTime());
        GameObject.FindGameObjectWithTag("InventoryImage").GetComponent<Image>().sprite =
            GameManager.Instance.CurrentSelected.GetComponent<InteractiveObjects>().objInfo.sprite_2;
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    IEnumerator WaitTime()
    {
        if (OnLevel != null)
        {
            if (OnLevel == VictoryChangeScene) OnLevel -= VictoryChangeScene;
            else if (OnLevel == VictoryChangeSceneToMainMenu) OnLevel -= VictoryChangeSceneToMainMenu;
            else OnLevel -= DefeatReloadScene;
        }
        yield return null;
    }
}
