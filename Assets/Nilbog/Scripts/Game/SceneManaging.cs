using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public static SceneManaging Instance;

    public delegate void Level();
    public static event Level OnLevel;

    private Scene scene;

    void Awake()
    {
        if (Instance != null && Instance == this) 
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
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

    public void DefeatReloadScene()
    {
        int sceneIndex = scene.buildIndex;
        StartCoroutine(WaitTime());
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    IEnumerator WaitTime()
    {
        OnLevel -= VictoryChangeScene;
        OnLevel -= DefeatReloadScene;
        Debug.Log(Time.time);
        yield return new WaitForSecondsRealtime(20f);
        Debug.Log(Time.time);
        yield return null;
    }
}