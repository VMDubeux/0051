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

    public GameObject canvasVitoria;

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
        canvasVitoria.SetActive(true);
        AudioManager.Instance.PlaySFX("Vitória", 1.0f);
        StartCoroutine(GoToScene(scene.buildIndex + 1));
    }

    public void VictoryChangeSceneToMainMenu()
    {
        canvasVitoria.SetActive(true);
        AudioManager.Instance.PlaySFX("Vitória", 1.0f);
        StartCoroutine(GoToScene(0));
    }

    public void DefeatReloadScene()
    {
        AudioManager.Instance.PlaySFX("Derrota", 1.0f);
        StartCoroutine(GoToScene(scene.buildIndex));
    }

    IEnumerator GoToScene(int targetScene)
    {
        if (OnLevel != null)
        {
            if (OnLevel == VictoryChangeScene) OnLevel -= VictoryChangeScene;
            else if (OnLevel == VictoryChangeSceneToMainMenu) OnLevel -= VictoryChangeSceneToMainMenu;
            else OnLevel -= DefeatReloadScene;
        }

        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
    }
}
