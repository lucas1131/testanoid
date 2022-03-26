using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GamePlay : IGamePlay
{
    private IBallController _ball;
    private IPlayerController _player;
    private IGameConfig _config;
    private IGlobalCoroutineDispatcher _dispatcher;
    private IScoreController _score;

    private uint _briks = 4;

    private Text _scoreText;
    private Text _livesText;
    private Text _getReadyText;

    private uint _lives;
    private bool GameEnded => _lives == 0;

    private Action _onPlayerWin;
    public Action OnPlayerWin {
        get => _onPlayerWin;
        set => _onPlayerWin = value;
    }

    private Action _onPlayerLose;
    public Action OnPlayerLose {
        get => _onPlayerLose;
        set => _onPlayerLose = value;
    }

    public bool GameIsRunning => !_getReadyText.enabled;

    public GamePlay(
        IBallController ball, 
        IPlayerController player, 
        IGameConfig config,
        IGlobalCoroutineDispatcher dispatcher,
        IScoreController _score,
        [Inject(Id=GamePlayInstaller.GameTextsIds.Score)] Text scoreText, 
        [Inject(Id=GamePlayInstaller.GameTextsIds.Lives)] Text livesText, 
        [Inject(Id=GamePlayInstaller.GameTextsIds.Ready)] Text getReadyText)
    {
        _ball = ball;
        _player = player;
        _config = config;
        _dispatcher = dispatcher;
        _scoreText = scoreText;
        _livesText = livesText;
        _getReadyText = getReadyText;

        SetupGame(config);
    }

    public void Goal()
    {
        _getReadyText.enabled = true;
        
        var pos1 = _player.GetPlayerPosition();
        pos1.x = 0f;
        _player.SetPlayerPosition(pos1);

        _ball.SetPosition(Vector3.zero);
        _ball.SetVelocity(Vector2.zero);

        _scoreText.text = _score.ToString();
        _livesText.text = _lives.ToString();

        Debug.Log($"Did player lose? {GameEnded}");
        if(!GameEnded) 
        {
            _dispatcher.Dispatch(StartGame());
        }
    }

    public void IncrementScore()
    {
        _score.Score++;
        _scoreText.text = _score.ToString();

        if(_score.Score == _briks)
        {
            Win();
        }
    }

    public void LoseLife()
    {
        _lives--;
        _livesText.text = _lives.ToString();

        Debug.Log("Losing a life");

        if(_lives == 0)
        {
            Lose();
        }
    }


    public void Win()
    {
        if(OnPlayerWin != null)
        {
            OnPlayerWin();
        }

        SceneManager.LoadScene("Win");
    }

    public void Lose()
    {
        if(OnPlayerLose != null)
        {
            OnPlayerLose();
        }

        SceneManager.LoadScene("Lose");
    }

    private void SetupGame(IGameConfig config)
    {
        _briks = 4;
        _score.Score = 0;
        _lives = config.Lives;

        _scoreText.text = _score.ToString();
        _livesText.text = _lives.ToString();

        Debug.Log($"Setting up games with {_lives} lives");

        Goal();
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);

        _getReadyText.enabled = false;
        _ball.Kick();
    }
}