using UnityEngine;
using Zenject;

public class Death : MonoBehaviour
{
	private IGamePlay _gamePlay;

	[Inject]
	private void Construct(IGamePlay gamePlay)
	{
		_gamePlay = gamePlay;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
    	_gamePlay.LoseLife();
    	_gamePlay.Goal();
    }
}