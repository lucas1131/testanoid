using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public interface IGamePlay
{
    bool GameIsRunning { get; }

    void Goal();
    void IncrementScore();
    void LoseLife();
    void Win();
    void Lose();
}