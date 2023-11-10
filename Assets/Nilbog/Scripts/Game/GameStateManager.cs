using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instace;
    
    public static GameStateManager Instace
    {
        get
        {
            if (_instace == null)
                _instace = new();
            return _instace;
        }
    }

    public GameState CurrentGameState { get; private set; }

    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged;

    private GameStateManager() 
    {
        
    }

    public void SetState(GameState newGameState) 
    {
        if (newGameState == CurrentGameState)
            return;

        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }
}
