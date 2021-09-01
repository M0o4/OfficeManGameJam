using System;

public static class VictoryScreen 
{
    public static event Action OnVictory;
    public static void Victory()
    {
        OnVictory?.Invoke();
    }
}
