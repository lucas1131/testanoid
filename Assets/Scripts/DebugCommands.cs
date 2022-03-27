using UnityEngine;
using Zenject;

public class DebugCommands : MonoBehaviour
{
#if true //debug commands
    private IGamePlay _gamePlay;

    [Inject]
    private void Construct(IGamePlay gamePlay)
    {
        _gamePlay = gamePlay;
    }

    private void Update()
    {

        if(!_gamePlay.GameIsRunning)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _gamePlay.Lose();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _gamePlay.Win();
        }
    }
#endif
}