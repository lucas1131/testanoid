using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public interface IGamePlay
{
    void Goal();
    void IncrementScore();
    void LoseLife();
    void Win();
    void Lose();
}