using UnityEngine;
using Zenject;

public class BrikController : MonoBehaviour
{    
    private IGamePlay _gamePlay;

    [Inject]
    private void Construct(IGamePlay gamePlay)
    {
        _gamePlay = gamePlay;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!_gamePlay.GameIsRunning)
        {
            return;
        }
        
        _gamePlay.IncrementScore();
        Destroy(gameObject);
    }
}