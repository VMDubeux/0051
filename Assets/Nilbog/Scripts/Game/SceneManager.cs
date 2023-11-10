using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    private static sbyte contadorInstanciaçoes = 1;

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
        sceneIndex = ++contadorInstanciaçoes;
        StartCoroutine(WaitTime());
        EditorSceneManager.LoadScene(sceneIndex);
        OnLevel -= VictoryChangeScene;
    }

    public void DefeatReloadScene()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        sceneIndex = contadorInstanciaçoes;
        GameStatus();
        yield return new WaitForSeconds(5);
        EditorSceneManager.LoadScene(contadorInstanciaçoes);
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
