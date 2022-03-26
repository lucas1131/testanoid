using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TopScore : MonoBehaviour
{
    public Text Label;
    private IGamePlay _gamePlay;

	[Inject]
	private void Construct(IGamePlay gamePlay)
	{
		_gamePlay = gamePlay;
	}
    
    private void Awake()
    {
    	// Debug.Log($"Top score: {_gamePlay.Score.ToString()}");
        // Label.text += _gamePlay.Score.ToString();
    }
}