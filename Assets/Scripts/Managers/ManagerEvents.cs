using REM;
using UnityEngine;

public class ManagerEvents : SingletonManager<ManagerEvents> {
    public delegate void AddScoreDelegate(int score);
    public static AddScoreDelegate OnAddScore;

    public delegate void SimpleDelegate();
    public SimpleDelegate GameStart;
    public SimpleDelegate GameLost;

    public void GameStart_()
    {
        GameStart?.Invoke();
    }

    public void GameLost_()
    {
        GameLost?.Invoke();
    }

    public void AddScore(int score)
    {
        OnAddScore?.Invoke(score);
    }

}