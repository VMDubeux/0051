using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    private static sbyte contadorInstancias = 1;

    [SerializeField]
    private sbyte sceneIndex;

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
        sceneIndex = ++contadorInstancias;
        StartCoroutine(WaitTime());
#if UNITY_EDITOR
        EditorSceneManager.LoadScene(sceneIndex);
#endif
        OnLevel -= VictoryChangeScene;
    }

    public void DefeatReloadScene()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        sceneIndex = contadorInstancias;
        GameStatus();
        yield return new WaitForSeconds(5);
#if UNITY_EDITOR
        EditorSceneManager.LoadScene(contadorInstancias);
#endif
        OnLevel -= DefeatReloadScene;
    }

    public void GameStatus()
    {
        GameState currentGameState = GameStateManager.Instace.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
            ? GameState.Paused
            : GameState.Gameplay;
        GameStateManager.Instace.SetState(newGameState);
    }
}
