using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TopScore : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    private IScoreController _score;

	[Inject]
	private void Construct(IScoreController score)
	{
		_score = score;
	}
    
    private void Start()
    {
        ScoreText.text += _score.Score.ToString();
    }
}