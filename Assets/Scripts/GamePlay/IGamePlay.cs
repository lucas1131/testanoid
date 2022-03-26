using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public interface IGamePlay
{
	uint Score { get; }

    void Goal();
    void IncrementScore();
    void LoseLife();
    void Win();
    void Lose();
}