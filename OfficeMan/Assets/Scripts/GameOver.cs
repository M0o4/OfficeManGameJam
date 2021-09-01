using System;
using UnityEngine;

public static class GameOver 
{
    public delegate void OnGameOver(string message);
    public static event OnGameOver onGameOver;
    public static void GameOverScreen(string message)
    {
        onGameOver?.Invoke(message);
    }
}
