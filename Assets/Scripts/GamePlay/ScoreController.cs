using System;

public class ScoreController : IScoreController
{
	private uint _score;
	public uint Score
	{
		get => _score;
		set => _score = value;
	}

	public new string ToString()
	{
		return _score.ToString();
	}
}