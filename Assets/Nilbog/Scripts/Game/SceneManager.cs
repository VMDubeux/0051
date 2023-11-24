using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    private static sbyte contadorInstancias = 1;

    public delegate void Level();
    public static event Level OnLevel;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    void Update()
    {
        if (OnLevel != null)
            OnLevel();
    }

    public void VictoryChangeScene()
    {
        sbyte sceneIndex = ++contadorInstancias;
        StartCoroutine(WaitTime());
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        OnLevel -= VictoryChangeScene;
    }

    public void DefeatReloadScene()
    {
        sbyte sceneIndex = contadorInstancias;
        StartCoroutine(WaitTime());
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        OnLevel -= DefeatReloadScene;
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5);
    }
}
