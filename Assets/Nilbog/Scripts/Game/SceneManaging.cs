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

    private int sceneNumber;
    private int actualScene;

    public Sprite image;

    void Awake()
    {
        actualScene = scene.buildIndex;

        if (Instance == null)
        {
            InstanceBasics();
        }
        else
        {
            if (actualScene != sceneNumber)
            {
                Destroy(GameObject.FindWithTag("SceneManaging"));
                InstanceBasics();
            }
            else if (!CompareTag("SceneManaging"))
            {
                Destroy(gameObject);
            }
        }
    }

    private void InstanceBasics()
    {
        Instance = this;
        gameObject.tag = "SceneManaging";
        sceneNumber = scene.buildIndex;
        DontDestroyOnLoad(gameObject);
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
        VoltarCena();
        int sceneIndex = scene.buildIndex;
        StartCoroutine(WaitTime());
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void VoltarCena()
    {
        Inventory.instance.AddImage(image);
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
