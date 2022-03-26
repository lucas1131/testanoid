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

    private uint _briks = 4;

    private Text _scoreText;
    private Text _livesText;
    private Text _getReadyText;


    private uint _score;
    private uint Score 
    {
        get => _score;
        set 
        {
            if(_score != value)
            {
                _score = value;
                if(_score == _briks)
                {
                    OnPlayerWin();
                }
            }
        }
    }

    private uint _lives;
    private uint Lives 
    {
        get => _lives;
        set 
        {
            if(_lives != value)
            {
                _lives = value;
                if(_lives == 0)
                {
                    OnPlayerLose();
                }
            }
        }
    }

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

    public GamePlay(
        IBallController ball, 
        IPlayerController player, 
        IGameConfig config,
        IGlobalCoroutineDispatcher dispatcher,
        [Inject(Id=GamePlayInstaller.GameTextsIds.Score)] Text scoreText, 
        [Inject(Id=GamePlayInstaller.GameTextsIds.Lives)] Text livesText, 
        [Inject(Id=GamePlayInstaller.GameTextsIds.Ready)] Text getReadyText)
    {

        Debug.Log($"Creating Gameplay");

        _ball = ball;
        _player = player;
        _config = config;
        _dispatcher = dispatcher;
        _scoreText = scoreText;
        _livesText = livesText;
        _getReadyText = getReadyText;

        OnPlayerWin += Win;
        OnPlayerLose += Lose;

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

        _dispatcher.Dispatch(StartGame());
    }

    public void IncrementScore()
    {
        _score++;
    }

    public void LoseLife()
    {
        _lives--;
    }
    

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose");
    }

    private void SetupGame(IGameConfig config)
    {
        _briks = 4;
        _score = 0;
        _lives = config.Lives;

        Goal();
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);

        _getReadyText.enabled = false;
        _ball.Kick();
    }
}